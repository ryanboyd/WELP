using System;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;





namespace WELP
{




    public partial class Form1 : Form
    {


        //this is what runs at initialization
        public Form1()
        {

            InitializeComponent();


            foreach (var encoding in Encoding.GetEncodings())
            {
                EncodingDropdown.Items.Add(encoding.Name);
            }


            if (EncodingDropdown.Items.Contains("utf-8")) {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact("utf-8");
            }
            else
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(Encoding.Default.BodyName);
            }


            TokenTextbox.Text = "happy\r\nwonderful\r\nterrific";

            OmissionValueComboBox.SelectedIndex = 2;

            EnclosedInQuotesDropdown.SelectedIndex = 1;
            HeaderRowDropdown.SelectedIndex = 0;
            
        }






//   _____ _ _      _       _____ _             _     ____        _   _              
//  / ____| (_)    | |     / ____| |           | |   |  _ \      | | | |             
// | |    | |_  ___| | __ | (___ | |_ __ _ _ __| |_  | |_) |_   _| |_| |_ ___  _ __  
// | |    | | |/ __| |/ /  \___ \| __/ _` | '__| __| |  _ <| | | | __| __/ _ \| '_ \ 
// | |____| | | (__|   <   ____) | || (_| | |  | |_  | |_) | |_| | |_| || (_) | | | |
//  \_____|_|_|\___|_|\_\ |_____/ \__\__,_|_|   \__| |____/ \__,_|\__|\__\___/|_| |_|
                                                                              
                                                                                   




        private void StartButton_Click(object sender, EventArgs e)
        {


            if (BgWorker.IsBusy)
            {
                BgWorker.CancelAsync();
                return;
            }


            string tokenstring = TokenTextbox.Text;
            tokenstring = tokenstring.Replace("\r\n", "\n").Replace('\r', '\n');
            tokenstring = tokenstring.Replace("\n", Environment.NewLine);
            tokenstring = tokenstring.Trim(Environment.NewLine.ToCharArray());

            string triplenewline = Environment.NewLine + Environment.NewLine + Environment.NewLine;
            string doublenewline = Environment.NewLine + Environment.NewLine;

            while (tokenstring.Contains(triplenewline))
            {
                tokenstring = tokenstring.Replace(triplenewline, doublenewline);
            }

            TokenTextbox.Text = tokenstring;


            //make sure the user has entered at least one thing
            if (TokenTextbox.Lines.Length == 0)
            {
                MessageBox.Show("You must enter at least one token.", "No Tokens Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LastColumnComboBox.SelectedIndex <= FirstColumnComboBox.SelectedIndex)
            {
                MessageBox.Show("Your \"Vector End\" column needs to come after\r\nyour \"Vector Start\" column.", "Invalid vector range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.Enabled = false;

            
            

            FolderBrowser.SelectedPath = Path.GetDirectoryName(openFileDialog.FileName);

            if (FolderBrowser.ShowDialog() != DialogResult.Cancel)
            {


                BgWorkerInformation BgData = new BgWorkerInformation();

                BgData.InputFile = FilenameDisplayBox.Text;
                BgData.OutputLocation = FolderBrowser.SelectedPath.ToString();
                BgData.HasHeaders = HeaderRowDropdown.SelectedItem.ToString();
                BgData.Delimiters = DelimiterTextBox.Text.ToString();
                BgData.UsingQuotes = EnclosedInQuotesDropdown.SelectedItem.ToString();

                BgData.TokenCol = TokenColumnComboBox.SelectedIndex;
                BgData.StartingCol = FirstColumnComboBox.SelectedIndex;
                BgData.EndingCol = LastColumnComboBox.SelectedIndex;

                

                //here, we have to go through some steps to get our user-submitted word list into
                //separate chunks. First, we figure out where empty linebreaks occur

                List<int> split_indices = new List<int>();
                int lastIndex = 0;

                while ((lastIndex = Array.IndexOf(TokenTextbox.Lines, "", lastIndex)) != -1)
                {
                    split_indices.Add(lastIndex);
                    lastIndex++;
                }


                //now, we set up an array of lists so that we can assign tokens to each
                //list
                List<string>[] token_list_array = new List<string>[split_indices.Count() + 1];
                for (int i = 0; i <= split_indices.Count(); i++) token_list_array[i] = new List<string>();

                string[] TokenTextbox_As_Array = TokenTextbox.Lines;

                //now, we do the assigning
                int split_position = 0;
                for (int i = 0; i < TokenTextbox_As_Array.Length; i++)
                {
                    if (split_position < split_indices.Count() && i >= split_indices[split_position])
                    {
                        split_position++;
                        continue;
                    }
                    token_list_array[split_position].Add(TokenTextbox_As_Array[i]);
                }


                BgData.Tokens = new HashSet<string>[token_list_array.Length];

                for (int i = 0; i < token_list_array.Length; i++)
                {
                    BgData.Tokens[i] = new HashSet<string>(token_list_array[i].Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray());
                }


                //we use "distinct" because we can't have dupes in a hashset
                BgData.Tokens_Altogether = new HashSet<string>(TokenTextbox.Lines.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray());






                BgData.OmitBelowValue = 1.0 - ((OmissionValueComboBox.SelectedIndex + 1.0) / 10.0);

                DisableButtons();

                StartButton.Text = "Cancel";

                try
                {
                    using (StreamWriter outputFile = new StreamWriter(new FileStream(Path.Combine(BgData.OutputLocation, "_WELP_SeedList.txt"),
                                                                                                        FileMode.Create, FileAccess.Write), Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString())))
                    {
                        outputFile.Write(TokenTextbox.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("There was an error writing your seed list to the" + "\r\n" +
                                "output directory. Please check all of your settings" + "\r\n" +
                               "and folders before starting again.", "Output Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    StartButton.Text = "Start!";
                    EnableButtons();
                    return;
                }

                BgWorker.RunWorkerAsync(BgData);

            }

            this.Enabled = true;
           
        }





        //  _                     _   _____        _          ____        _   _              
        // | |                   | | |  __ \      | |        |  _ \      | | | |             
        // | |     ___   __ _  __| | | |  | | __ _| |_ __ _  | |_) |_   _| |_| |_ ___  _ __  
        // | |    / _ \ / _` |/ _` | | |  | |/ _` | __/ _` | |  _ <| | | | __| __/ _ \| '_ \ 
        // | |___| (_) | (_| | (_| | | |__| | (_| | || (_| | | |_) | |_| | |_| || (_) | | | |
        // |______\___/ \__,_|\__,_| |_____/ \__,_|\__\__,_| |____/ \__,_|\__|\__\___/|_| |_|
        //                                                                                   


        private void GeneratePreviewButton_Click(object sender, EventArgs e)
        {

            FirstColumnComboBox.Items.Clear();
            LastColumnComboBox.Items.Clear();
            TokenColumnComboBox.Items.Clear();

            FilenameDisplayBox.Text = "No file selected...";

            FilenameLabel.Text = "Clearing old preview... (This might take a while for previews with a large number of columns.)";
            FilenameLabel.Invalidate();
            FilenameLabel.Update();
            FilenameLabel.Refresh();

            dataGridView1.DataSource = null;
            FilenameLabel.Text = "Ready to load a data file preview.";

            openFileDialog.Title = "Please select you data file...";

                DialogResult InputFileDialog = openFileDialog.ShowDialog();

                if (InputFileDialog != DialogResult.Cancel)
                {

                    DisableButtons();
                    string InputFile = openFileDialog.FileName;

                    FilenameDisplayBox.Text = InputFile;

                    FilenameDisplayBox.Focus();
                    // Move the caret to the end of the text box
                    FilenameDisplayBox.Select(FilenameDisplayBox.Text.Length, 0);


                BgWorkerInformation BgData = new BgWorkerInformation();

                    BgData.InputFile = FilenameDisplayBox.Text;
                    BgData.HasHeaders = HeaderRowDropdown.SelectedItem.ToString();
                    BgData.Delimiters = DelimiterTextBox.Text.ToString();
                    BgData.UsingQuotes = EnclosedInQuotesDropdown.SelectedItem.ToString();

                    LoadCSVPreview_BGWorker.RunWorkerAsync(BgData);
                }
            else
            {
                FilenameDisplayBox.Text = "No file selected...";
                StartButton.Enabled = false;
                ReloadCSVButton.Enabled = false;
                FirstColumnComboBox.Items.Clear();
                LastColumnComboBox.Items.Clear();
                TokenColumnComboBox.Items.Clear();
            }
        }





        //  _____      _                 _   _____        _          ______ _ _      
        // |  __ \    | |               | | |  __ \      | |        |  ____(_) |     
        // | |__) |___| | ___   __ _  __| | | |  | | __ _| |_ __ _  | |__   _| | ___ 
        // |  _  // _ \ |/ _ \ / _` |/ _` | | |  | |/ _` | __/ _` | |  __| | | |/ _ \
        // | | \ \  __/ | (_) | (_| | (_| | | |__| | (_| | || (_| | | |    | | |  __/
        // |_|  \_\___|_|\___/ \__,_|\__,_| |_____/ \__,_|\__\__,_| |_|    |_|_|\___|




        private void ReloadCSVButton_Click(object sender, EventArgs e)
        {

            FilenameLabel.Text = "Clearing old preview... (This might take a while for previews with a large number of columns.)";
            FilenameLabel.Invalidate();
            FilenameLabel.Update();
            FilenameLabel.Refresh();

            dataGridView1.DataSource = null;
            FilenameLabel.Text = "Ready to load a data file preview.";

            if (FilenameDisplayBox.Text != "No file selected...")
            {

                DisableButtons();
                BgWorkerInformation BgData = new BgWorkerInformation();

                BgData.InputFile = FilenameDisplayBox.Text;
                BgData.HasHeaders = HeaderRowDropdown.SelectedItem.ToString();
                BgData.Delimiters = DelimiterTextBox.Text.ToString();
                BgData.UsingQuotes = EnclosedInQuotesDropdown.SelectedItem.ToString();

                LoadCSVPreview_BGWorker.RunWorkerAsync(BgData);
            }
        }







        //   _____                           _         _____                _               
        //  / ____|                         | |       |  __ \              (_)              
        // | |  __  ___ _ __   ___ _ __ __ _| |_ ___  | |__) | __ _____   ___  _____      __
        // | | |_ |/ _ \ '_ \ / _ \ '__/ _` | __/ _ \ |  ___/ '__/ _ \ \ / / |/ _ \ \ /\ / /
        // | |__| |  __/ | | |  __/ | | (_| | ||  __/ | |   | | |  __/\ V /| |  __/\ V  V / 
        //  \_____|\___|_| |_|\___|_|  \__,_|\__\___| |_|   |_|  \___| \_/ |_|\___| \_/\_/  
        //                                                                                                 






        private void LoadCSVPreview_BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            //here, we're basically unpacking and redefining all of the core information that was
            //passed to the background worker. it's a bit redundant and not super efficient, but the
            //loss of efficiency is more than made up for by the gains in readability

            BgWorkerInformation BgData = (BgWorkerInformation) e.Argument;

            Encoding SelectedEncoding = null;

            string InputFile = BgData.InputFile;
            bool HasHeaders = Convert.ToBoolean(BgData.HasHeaders);
            string[] Delimiters = BgData.Delimiters.ToCharArray().Select(c => c.ToString()).ToArray(); ;
            bool UsingQuotes = Convert.ToBoolean(BgData.UsingQuotes);



            this.Invoke((MethodInvoker)delegate ()
            {
                SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());
            });


            // a data table we'll use to hold the parsed data
            DataTable dt = new DataTable();


            try
            {
                // create the parser
                using (TextFieldParser parser = new TextFieldParser(InputFile, SelectedEncoding))
                {
                    // set the parser variables
                    parser.TrimWhiteSpace = true;
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(Delimiters);
                    parser.HasFieldsEnclosedInQuotes = UsingQuotes;

                    int LineNumber = 0;
                    bool firstLine = true;

                    //report what we're working on
                    FilenameLabel.Invoke((MethodInvoker)delegate
                    {
                        FilenameLabel.Text = "Preparing to read data file for preview...";
                    });


                    while (!parser.EndOfData)
                    {

                        

                        //report what we're working on
                        FilenameLabel.Invoke((MethodInvoker)delegate
                        {
                            FilenameLabel.Text = "Loading data file for preview... Data Row #" + LineNumber.ToString();
                        });


                        //Processing row
                        string[] fields = parser.ReadFields();

                        LineNumber++;

                        // get the column headers
                        if (firstLine)
                        {

                            firstLine = false;

                            if (HasHeaders)
                            {
                                foreach (var val in fields)
                                {
                                    dt.Columns.Add(val);
                                }
                                LineNumber--;
                                continue;
                            }
                            else
                            {
                                for (int i = 1; i <= fields.Length; i++)
                                {
                                    dt.Columns.Add("v" + i.ToString());
                                }

                            }
                        }


                        // get the row data
                        dt.Rows.Add(fields);

                        if (LineNumber > 999)
                        {
                            break;
                        }

                    }

                }

                e.Result = dt;

                if (dt.Columns.Count < 1 || dt.Rows.Count < 1)
                {
                    MessageBox.Show("Your spreadsheet file could not be properly parsed" + "\r\n" +
                                "with the current settings. WELP could not find any" + "\r\n" +
                               "distinct columns and/or rows in your data file. This is" + "\r\n" +
                               "most often caused by using the wrong delimiter(s).", "Data Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                //what to do if there's an error
                e.Result = false;
            }

        }

        private void LoadCSVPreview_BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            FilenameLabel.Text = "Please wait while preview is being generated... (This might take a while for files with a large number of columns.)";
            FilenameLabel.Invalidate();
            FilenameLabel.Update();
            FilenameLabel.Refresh();
            Application.DoEvents();

            //bind the results to the datagridview
            try { 
                dataGridView1.DataSource = e.Result;
                EnableButtons();
                ReloadCSVButton.Enabled = true;
                StartButton.Enabled = true;
                MessageBox.Show("Your data file preview has been loaded." + "\r\n\r\n" + 
                                "If your preview window appears to be empty, you most likely need to edit your settings under the \"Options for Reading Data File\" section.", "Preview Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {

                    TokenColumnComboBox.Items.Add(column.HeaderText);
                    FirstColumnComboBox.Items.Add(column.HeaderText);
                    LastColumnComboBox.Items.Add(column.HeaderText);
                }

                TokenColumnComboBox.SelectedIndex = 0;
                FirstColumnComboBox.SelectedIndex = 0;
                LastColumnComboBox.SelectedIndex = LastColumnComboBox.Items.Count - 1;

            }
            catch
            {

                ReloadCSVButton.Enabled = false;
                StartButton.Enabled = false;

                MessageBox.Show("Your spreadsheet file could not be properly parsed" + "\r\n" +
                                "with the current settings. Please make sure that the" + "\r\n" +
                               "file is not open elsewhere, check your settings, and" + "\r\n" + 
                               "try again.", "Data Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FilenameLabel.Text = "Finished creating dataset preview.";

        }













        //  ____   ______        __         _                ___   _                          _     _  __ _   _           __  
        // | __ ) / ___\ \      / /__  _ __| | _____ _ __   / / | | | ___  __ ___   ___   _  | |   (_)/ _| |_(_)_ __   __ \ \ 
        // |  _ \| |  _ \ \ /\ / / _ \| '__| |/ / _ \ '__| | || |_| |/ _ \/ _` \ \ / / | | | | |   | | |_| __| | '_ \ / _` | |
        // | |_) | |_| | \ V  V / (_) | |  |   <  __/ |    | ||  _  |  __/ (_| |\ V /| |_| | | |___| |  _| |_| | | | | (_| | |
        // |____/ \____|  \_/\_/ \___/|_|  |_|\_\___|_|    | ||_| |_|\___|\__,_| \_/  \__, | |_____|_|_|  \__|_|_| |_|\__, | |
        //                                                  \_\                       |___/                           |___/_/ 



        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //here, we're basically unpacking and redefining all of the core information that was
            //passed to the background worker. it's a bit redundant and not super efficient, but the
            //loss of efficiency is more than made up for by the gains in readability

            BgWorkerInformation BgData = (BgWorkerInformation)e.Argument;

            Encoding SelectedEncoding = null;

            string InputFile = BgData.InputFile;
            bool HasHeaders = Convert.ToBoolean(BgData.HasHeaders);
            string[] Delimiters = BgData.Delimiters.ToCharArray().Select(c => c.ToString()).ToArray(); ;
            bool UsingQuotes = Convert.ToBoolean(BgData.UsingQuotes);
            
            //initialize what we'll need later


            this.Invoke((MethodInvoker)delegate ()
            {
                SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());
            });

            ulong Total_Number_of_Tokens = Convert.ToUInt64(BgData.Tokens_Altogether.Count());
            ulong number_of_word_lists = Convert.ToUInt64(BgData.Tokens.Count());


            int vectorlength = BgData.EndingCol - BgData.StartingCol + 1;
            double[][] averagevector = new double[number_of_word_lists][];
            for (ulong i = 0; i < number_of_word_lists; i++)
            {
                averagevector[i] = new double[vectorlength];
                for (int j = 0; j < vectorlength; j++) averagevector[i][j] = 0;
            }




            try
            {

                

                // create the parser
                using (TextFieldParser parser = new TextFieldParser(InputFile, SelectedEncoding))
                {


                using (StreamWriter outputFile_subvectors = new StreamWriter(new FileStream(Path.Combine(BgData.OutputLocation, "_WELP_Subvectors.txt"),
                                                                                                        FileMode.Create, FileAccess.Write), SelectedEncoding))
                {

                
                

                    // set the parser properties
                    parser.TrimWhiteSpace = true; //trim the whitespace to make sure that files/folder names don't end with a space, which will break the program
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(Delimiters);
                    parser.HasFieldsEnclosedInQuotes = UsingQuotes;

                    //this is used for header handling and reporting
                    bool firstLine = true;
                    ulong LineNumber = 0;
                    ulong detected_tokens_altogether = 0;
                    

                    


                    ulong[] detected_tokens_per_wordlist = new ulong[number_of_word_lists];
                    for (ulong i = 0; i < number_of_word_lists; i++) detected_tokens_per_wordlist[i] = 0;

                    HashSet <string>[] Detected_Token_Hashset = new HashSet<string>[BgData.Tokens.Length];
                    for (int i = 0; i < BgData.Tokens.Length; i++) Detected_Token_Hashset[i] = new HashSet<string>();

                    //report what we're working on
                    FilenameLabel.Invoke((MethodInvoker)delegate
                    {
                        FilenameLabel.Text = "Preparing...";
                    });



                    //Loop through each row of the dataset
                    while (!parser.EndOfData && !BgWorker.CancellationPending)
                    {

                        //parse out the row
                        string[] fields = parser.ReadFields();

                        LineNumber++;

                        //report what row we're working on
                        if (LineNumber % 100 == 0)
                        {
                            FilenameLabel.Invoke((MethodInvoker)delegate
                                {
                                    FilenameLabel.Text = "Getting average vector(s)... Currently reading row #" + LineNumber.ToString();
                                });
                        }


                        // get the column headers
                        if (firstLine)
                        {

                            firstLine = false;
                            //essentially, if the first line of the dataset is headers, we'll just skip on to the next line
                            if (HasHeaders)
                            {
                                LineNumber--;
                                continue;
                            }
                        }



                        //first, we want to know if the row even contains a token in our list:
                        if (BgData.Tokens_Altogether.Contains(fields[BgData.TokenCol]))
                        {

                            detected_tokens_altogether++;
                            //if it does, then we go in and figure out which word lists contain the word in
                            //question, and do the basic "add word vectors" for each word list that contains it
                            for (ulong wordlist_counter = 0; wordlist_counter < number_of_word_lists; wordlist_counter++)
                            {

                                

                                if (BgData.Tokens[wordlist_counter].Contains(fields[BgData.TokenCol]))
                                {

                                    Detected_Token_Hashset[wordlist_counter].Add(fields[BgData.TokenCol]);
                                    
                                    detected_tokens_per_wordlist[wordlist_counter]++;

                                    try
                                    {

                                        //copy just the vector into a new array
                                        string[] vector = new string[vectorlength];
                                        Array.Copy(fields, BgData.StartingCol, vector, 0, vectorlength);
                                        double[] vector_numeric = Array.ConvertAll(vector, Double.Parse);

                                        outputFile_subvectors.WriteLine(fields[BgData.TokenCol] + "\t" + string.Join("\t", vector));

                                        //add values from the new vector
                                        for (int i = 0; i < vectorlength; i++)
                                        {
                                            averagevector[wordlist_counter][i] += vector_numeric[i];
                                        }
                                    }
                                    catch
                                    {
                                        DialogResult result = MessageBox.Show("There was an error reading your vectors." + "\r\n" +
                                                                              "Are you sure that you selected columns that only contain numbers?",
                                                                              "Vector parsing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        e.Cancel = true;
                                        break;
                                    }


                                }


                            }


                            





                        }


                        //if we've found all of the tokens, we don't need to keep looking
                        if(detected_tokens_altogether == Total_Number_of_Tokens) break;
                        

                        if (e.Cancel)
                        {
                            break;
                        }


                    //end of while for going through data
                    }



                    //let user know if there was an issue with finding tokens
                    if (detected_tokens_altogether == 0)
                    {
                        MessageBox.Show("None of the tokens in your list were found.",
                                                              "No Tokens Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;

                    }



                    if (!e.Cancel)
                    {


                        //probably write a file of tokens that *were* captured
                        StringBuilder tokens_found_output = new StringBuilder();

                        

                        for (ulong wordlist_counter = 0; wordlist_counter < number_of_word_lists; wordlist_counter++)
                        {

                            //calculate the average vector
                            //add values from the new vector
                            for (int i = 0; i < vectorlength; i++)
                            {
                                averagevector[wordlist_counter][i] = averagevector[wordlist_counter][i] / detected_tokens_per_wordlist[wordlist_counter];
                            }

                            string[] tokens_as_array = BgData.Tokens[wordlist_counter].ToArray();
                            List<string> UndetectedTokens = new List<string>();
                            //figure out which words were not caught
                            for (int i = 0; i < tokens_as_array.Length; i++)
                            {
                                if (!Detected_Token_Hashset[wordlist_counter].Contains(tokens_as_array[i])) UndetectedTokens.Add(tokens_as_array[i]);
                            }

                            tokens_found_output.Append("\r\n------------------------------------------------\r\n" + 
                                                   "TOKENS FOUND, WORD GROUP #" + (wordlist_counter + 1).ToString() + ":" + 
                                                   "\r\n------------------------------------------------\r\n" + 
                                                   string.Join("\r\n", Detected_Token_Hashset[wordlist_counter]));

                            tokens_found_output.Append("\r\n\r\n\r\n" + 
                                                   "\r\n------------------------------------------------\r\n" +
                                                   "TOKENS NOT FOUND, WORD GROUP #" + (wordlist_counter + 1).ToString() + ":" +
                                                   "\r\n------------------------------------------------\r\n" + 
                                                   string.Join("\r\n", UndetectedTokens) +
                                                   "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");


                        }

                        


                        try
                        {

                            using (StreamWriter outputFile = new StreamWriter(new FileStream(Path.Combine(BgData.OutputLocation, "_WELP_AvgVector.txt"),
                                                                                                            FileMode.Create, FileAccess.Write), SelectedEncoding))
                            {
                                for (ulong wordlist_counter = 0; wordlist_counter < number_of_word_lists; wordlist_counter++) outputFile.WriteLine("Word_Group_" + (wordlist_counter + 1).ToString() + "\t" + 
                                                                                                                                                string.Join("\t", averagevector[wordlist_counter]));
                            }

                            
                            

                            using (StreamWriter outputFile = new StreamWriter(new FileStream(Path.Combine(BgData.OutputLocation, "_WELP_TokensFound.txt"),
                                                                                                            FileMode.Create, FileAccess.Write), SelectedEncoding))
                            {
                                outputFile.Write(tokens_found_output);
                            }


                        }

                        catch
                        {
                            DialogResult result = MessageBox.Show("There was an error writing your output.",
                                                                  "Write file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;

                        }
                    }

                //end "using" for retained vector output
                }

                //end of "using" textfieldparser
                }

            //end of try
            }
            catch
            {
                DialogResult result = MessageBox.Show("An error occurred somewhere while trying to parse your model file.",
                                                      "General Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }






            //   ____      _            _       _          ____          _              ____  _           _ _            _ _   _           
            //  / ___|__ _| | ___ _   _| | __ _| |_ ___   / ___|___  ___(_)_ __   ___  / ___|(_)_ __ ___ (_) | __ _ _ __(_) |_(_) ___  ___ 
            // | |   / _` | |/ __| | | | |/ _` | __/ _ \ | |   / _ \/ __| | '_ \ / _ \ \___ \| | '_ ` _ \| | |/ _` | '__| | __| |/ _ \/ __|
            // | |__| (_| | | (__| |_| | | (_| | ||  __/ | |__| (_) \__ \ | | | |  __/  ___) | | | | | | | | | (_| | |  | | |_| |  __/\__ \
            //  \____\__,_|_|\___|\__,_|_|\__,_|\__\___|  \____\___/|___/_|_| |_|\___| |____/|_|_| |_| |_|_|_|\__,_|_|  |_|\__|_|\___||___/
            //                                                                                                                             

            try
            {
                if (!e.Cancel)
                {

                    using (TextFieldParser parser = new TextFieldParser(InputFile, SelectedEncoding))
                    {


                        // set the parser properties
                        parser.TrimWhiteSpace = true; //trim the whitespace to make sure that files/folder names don't end with a space, which will break the program
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(Delimiters);
                        parser.HasFieldsEnclosedInQuotes = UsingQuotes;

                        //this is used for header handling and reporting
                        bool firstLine = true;
                        ulong LineNumber = 0;



                        using (StreamWriter outputFile = new StreamWriter(new FileStream(Path.Combine(BgData.OutputLocation, "_WELP_CosineSim.csv"),
                                                                                                            FileMode.Create, FileAccess.Write), SelectedEncoding))
                        {


                            //write the header row
                            string header = "\"Token\"";
                            for (ulong i = 0; i < number_of_word_lists; i++) header += ",\"Grp_" + (i + 1).ToString() + "_CosineSim\"";
                            outputFile.WriteLine(header);


                            while (!parser.EndOfData && !BgWorker.CancellationPending)
                            {

                                //parse out the row
                                string[] fields = parser.ReadFields();

                                LineNumber++;

                                //report what row we're working on
                                if (LineNumber % 100 == 0)
                                {
                                    FilenameLabel.Invoke((MethodInvoker)delegate
                                    {
                                        FilenameLabel.Text = "Calculating cosine similarities... Currently reading row #" + LineNumber.ToString();
                                    });
                                }


                                // get the column headers
                                if (firstLine)
                                {

                                    firstLine = false;
                                    //essentially, if the first line of the dataset is headers, we'll just skip on to the next line
                                    if (HasHeaders)
                                    {
                                        LineNumber--;
                                        continue;
                                    }
                                }

                                try
                                {
                                    //if if's not the header row, then let's  get the vector
                                    string[] vector = new string[vectorlength];
                                    Array.Copy(fields, BgData.StartingCol, vector, 0, vectorlength);
                                    double[] vector_numeric = Array.ConvertAll(vector, Double.Parse);

                                    //let's calculate the cosine similarity between our mean vector
                                    //and the token on the current row

                                    //https://janav.wordpress.com/2013/10/27/tf-idf-and-cosine-similarity/
                                    //Cosine Similarity (d1, d2) =  Dot product(d1, d2) / ||d1|| * ||d2||
                                    //
                                    //Dot product (d1,d2) = d1[0] * d2[0] + d1[1] * d2[1] * … * d1[n] * d2[n]
                                    //||d1|| = square root(d1[0]2 + d1[1]2 + ... + d1[n]2)
                                    //||d2|| = square root(d2[0]2 + d2[1]2 + ... + d2[n]2)



                                    bool at_least_one_cossim = false;
                                    double[] CosineSims = new double[number_of_word_lists];
                                    

                                    for (ulong wordlist_counter = 0; wordlist_counter < number_of_word_lists; wordlist_counter++)
                                    {


                                        double dotproduct = 0;
                                        double d1 = 0;
                                        double d2 = 0;

                                        //calculate cosine similarity components
                                        for (int i = 0; i < vectorlength; i++)
                                        {
                                            dotproduct += averagevector[wordlist_counter][i] * vector_numeric[i];
                                            d1 += averagevector[wordlist_counter][i] * averagevector[wordlist_counter][i];
                                            d2 += vector_numeric[i] * vector_numeric[i];
                                        }

                                        CosineSims[wordlist_counter] = dotproduct / (Math.Sqrt(d1) * Math.Sqrt(d2));

                                        if (Math.Abs(CosineSims[wordlist_counter]) > BgData.OmitBelowValue) at_least_one_cossim = true;


                                    }



                                    if (BgData.OmitBelowValue == 0.0 || at_least_one_cossim)
                                    {

                                        StringBuilder LineToWrite = new StringBuilder();

                                        //write the output, making sure to escape quotes
                                        if (fields[BgData.TokenCol].Contains('"'))
                                        {
                                            LineToWrite.Append("\"" + fields[BgData.TokenCol].Replace("\"", "\"\"") + "\"");
                                        }
                                        else
                                        {
                                            LineToWrite.Append("\"" + fields[BgData.TokenCol] + "\"");
                                        }




                                        for (ulong wordlist_counter = 0; wordlist_counter < number_of_word_lists; wordlist_counter++)
                                        {
                                            if (BgData.OmitBelowValue == 0.0 || Math.Abs(CosineSims[wordlist_counter]) > BgData.OmitBelowValue)
                                            {
                                                LineToWrite.Append("," + CosineSims[wordlist_counter]);
                                            }
                                            else
                                            {
                                                LineToWrite.Append(",");
                                            }
                                        }

                                        outputFile.WriteLine(LineToWrite);

                                    }


                                }
                                catch
                                {
                                    DialogResult result = MessageBox.Show("There was an error reading your vectors." + "\r\n" +
                                                                          "Are you sure that you selected columns that only contain numbers?",
                                                                          "Vector parsing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    e.Cancel = true;
                                    break;
                                }



                                //end while
                            }

                            //end "using" for file output
                        }


                        //end "using" for textfieldparser
                    }


                    //end of "if e.cancel is false"
                }

            //end of try
            }
            catch
            {
                DialogResult result = MessageBox.Show("An error occurred somewhere while trying to calculate similarities.",
                                                      "General Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;

            }


        }


        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartButton.Text = "Start!";
            EnableButtons();
            FilenameLabel.Text = "Finished!  :)";
            MessageBox.Show("WELP has finished conducting your analysis!", "Analysis Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
























        //this override makes sure that we don't get errors thrown for fillweight violations.
        //it also sets the basic column width, which is useful for when it only finds one column
        //and looks like nothing is there with default settings
        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
            e.Column.Width = 100;
        }


        public void DisableButtons()
        {
            LoadCSVButton.Enabled = false;
            ReloadCSVButton.Enabled = false;

            DelimiterTextBox.Enabled = false;
            EnclosedInQuotesDropdown.Enabled = false;
            HeaderRowDropdown.Enabled = false;
            EncodingDropdown.Enabled = false;

            TokenTextbox.Enabled = false;

            TokenColumnComboBox.Enabled = false;
            FirstColumnComboBox.Enabled = false;
            LastColumnComboBox.Enabled = false;

            OmissionValueComboBox.Enabled = false;

        }


        public void EnableButtons()
        {
            LoadCSVButton.Enabled = true;
            ReloadCSVButton.Enabled = true;
            
            DelimiterTextBox.Enabled = true;
            EnclosedInQuotesDropdown.Enabled = true;
            HeaderRowDropdown.Enabled = true;
            EncodingDropdown.Enabled = true;

            TokenTextbox.Enabled = true;

            TokenColumnComboBox.Enabled = true;
            FirstColumnComboBox.Enabled = true;
            LastColumnComboBox.Enabled = true;

            OmissionValueComboBox.Enabled = true;

        }




        public class BgWorkerInformation
        {
            public string InputFile { get; set; }
            public string OutputLocation { get; set; }
            public string HasHeaders { get; set; }
            public string Delimiters { get; set; }
            public string UsingQuotes { get; set; }

            public int StartingCol { get; set; }
            public int EndingCol { get; set; }
            public int TokenCol { get; set; }
            public HashSet<string>[] Tokens { get; set; }
            public HashSet<string> Tokens_Altogether { get; set; }


            public double OmitBelowValue { get; set; }


        }



        private void SubfolderCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
                 
        }

        //https://stackoverflow.com/a/1739058
        static object InitializeJaggedArray(Type type, ulong index, int[] lengths)
        {
            Array array = Array.CreateInstance(type, lengths[index]);
            Type elementType = type.GetElementType();

            if (elementType != null)
            {
                for (int i = 0; i < lengths[index]; i++)
                {
                    array.SetValue(
                        InitializeJaggedArray(elementType, index + 1, lengths), i);
                }
            }

            return array;
        }


    }












    

}
