﻿//<Snippet0>
using System;
using System.Windows.Forms;
using System.Security.Permissions;

public class Form1 : Form
{
    public Form1()
    {
        // Create the form layout. If you are using Visual Studio, 
        // you can replace this code with code generated by the designer. 
        InitializeForm();

        // The following events are not visible in the designer, so 
        // you must associate them with their event-handlers in code.
        webBrowser1.CanGoBackChanged +=
            new EventHandler(webBrowser1_CanGoBackChanged);
        webBrowser1.CanGoForwardChanged +=
            new EventHandler(webBrowser1_CanGoForwardChanged);
        webBrowser1.DocumentTitleChanged +=
            new EventHandler(webBrowser1_DocumentTitleChanged);
        webBrowser1.StatusTextChanged +=
            new EventHandler(webBrowser1_StatusTextChanged);

        // Load the user's home page.
        webBrowser1.GoHome();
    }

    //<Snippet1>
    // Displays the Save dialog box.
    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        webBrowser1.ShowSaveAsDialog();
    }
    //</Snippet1>

    //<Snippet2>
    // Displays the Page Setup dialog box.
    private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        webBrowser1.ShowPageSetupDialog();
    }
    //</Snippet2>

    //<Snippet3>
    // Displays the Print dialog box.
    private void printToolStripMenuItem_Click(object sender, EventArgs e)
    {
        webBrowser1.ShowPrintDialog();
    }
    //</Snippet3>

    //<Snippet4>
    // Displays the Print Preview dialog box.
    private void printPreviewToolStripMenuItem_Click(
        object sender, EventArgs e)
    {
        webBrowser1.ShowPrintPreviewDialog();
    }
    //</Snippet4>

    //<Snippet5>
    // Displays the Properties dialog box.
    private void propertiesToolStripMenuItem_Click(
        object sender, EventArgs e)
    {
        webBrowser1.ShowPropertiesDialog();
    }
    //</Snippet5>

    // Selects all the text in the text box when the user clicks it. 
    private void toolStripTextBox1_Click(object sender, EventArgs e)
    {
        toolStripTextBox1.SelectAll();
    }

    //<Snippet6>
    // Navigates to the URL in the address box when 
    // the ENTER key is pressed while the ToolStripTextBox has focus.
    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Navigate(toolStripTextBox1.Text);
        }
    }

    // Navigates to the URL in the address box when 
    // the Go button is clicked.
    private void goButton_Click(object sender, EventArgs e)
    {
        Navigate(toolStripTextBox1.Text);
    }

    // Navigates to the given URL if it is valid.
    private void Navigate(String address)
    {
        if (String.IsNullOrEmpty(address)) return;
        if (address.Equals("about:blank")) return;
        if (!address.StartsWith("http://") &&
            !address.StartsWith("https://"))
        {
            address = "http://" + address;
        }
        try
        {
            webBrowser1.Navigate(new Uri(address));
        }
        catch (System.UriFormatException)
        {
            return;
        }
    }

    // Updates the URL in TextBoxAddress upon navigation.
    private void webBrowser1_Navigated(object sender,
        WebBrowserNavigatedEventArgs e)
    {
        toolStripTextBox1.Text = webBrowser1.Url.ToString();
    }
    //</Snippet6>

    //<Snippet7>
    // Navigates webBrowser1 to the previous page in the history.
    private void backButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoBack();
    }

    // Disables the Back button at the beginning of the navigation history.
    private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
    {
        backButton.Enabled = webBrowser1.CanGoBack;
    }
    //</Snippet7>

    //<Snippet8>
    // Navigates webBrowser1 to the next page in history.
    private void forwardButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoForward();
    }

    // Disables the Forward button at the end of navigation history.
    private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
    {
        forwardButton.Enabled = webBrowser1.CanGoForward;
    }
    //</Snippet8>

    //<Snippet9>
    // Halts the current navigation and any sounds or animations on 
    // the page.
    private void stopButton_Click(object sender, EventArgs e)
    {
        webBrowser1.Stop();
    }
    //</Snippet9>

    //<Snippet10>
    // Reloads the current page.
    private void refreshButton_Click(object sender, EventArgs e)
    {
        // Skip refresh if about:blank is loaded to avoid removing
        // content specified by the DocumentText property.
        if (!webBrowser1.Url.Equals("about:blank"))
        {
            webBrowser1.Refresh();
        }
    }
    //</Snippet10>

    //<Snippet11>
    // Navigates webBrowser1 to the home page of the current user.
    private void homeButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoHome();
    }
    //</Snippet11>

    //<Snippet12>
    // Navigates webBrowser1 to the search page of the current user.
    private void searchButton_Click(object sender, EventArgs e)
    {
        webBrowser1.GoSearch();
    }
    //</Snippet12>

    //<Snippet13>
    // Prints the current document using the current print settings.
    private void printButton_Click(object sender, EventArgs e)
    {
        webBrowser1.Print();
    }
    //</Snippet13>

    //<Snippet14>
    // Updates the status bar with the current browser status text.
    private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
    {
        toolStripStatusLabel1.Text = webBrowser1.StatusText;
    }
    //</Snippet14>

    //<Snippet15>
    // Updates the title bar with the current document title.
    private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
    {
        this.Text = webBrowser1.DocumentTitle;
    }
    //</Snippet15>

    // Exits the application.
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    // The remaining code in this file provides basic form initialization and 
    // includes a Main method. If you use the Visual Studio designer to create
    // your form, you can use the designer generated code instead of this code, 
    // but be sure to use the names shown in the variable declarations here,
    // and be sure to attach the event handlers to the associated events. 

    private WebBrowser webBrowser1;

    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem,
        saveAsToolStripMenuItem, printToolStripMenuItem,
        printPreviewToolStripMenuItem, exitToolStripMenuItem,
        pageSetupToolStripMenuItem, propertiesToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1, toolStripSeparator2;

    private ToolStrip toolStrip1, toolStrip2;
    private ToolStripTextBox toolStripTextBox1;
    private ToolStripButton goButton, backButton,
        forwardButton, stopButton, refreshButton,
        homeButton, searchButton, printButton;

    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;

    private void InitializeForm()
    {
        webBrowser1 = new WebBrowser();

        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        printToolStripMenuItem = new ToolStripMenuItem();
        printPreviewToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        pageSetupToolStripMenuItem = new ToolStripMenuItem();
        propertiesToolStripMenuItem = new ToolStripMenuItem();

        toolStrip1 = new ToolStrip();
        goButton = new ToolStripButton();
        backButton = new ToolStripButton();
        forwardButton = new ToolStripButton();
        stopButton = new ToolStripButton();
        refreshButton = new ToolStripButton();
        homeButton = new ToolStripButton();
        searchButton = new ToolStripButton();
        printButton = new ToolStripButton();

        toolStrip2 = new ToolStrip();
        toolStripTextBox1 = new ToolStripTextBox();

        statusStrip1 = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();

        menuStrip1.Items.Add(fileToolStripMenuItem);

        fileToolStripMenuItem.DropDownItems.AddRange(
            new ToolStripItem[] {
                saveAsToolStripMenuItem, toolStripSeparator1, 
                pageSetupToolStripMenuItem, printToolStripMenuItem, 
                printPreviewToolStripMenuItem, toolStripSeparator2,
                propertiesToolStripMenuItem, exitToolStripMenuItem
            });

        fileToolStripMenuItem.Text = "&File";
        saveAsToolStripMenuItem.Text = "Save &As...";
        pageSetupToolStripMenuItem.Text = "Page Set&up...";
        printToolStripMenuItem.Text = "&Print...";
        printPreviewToolStripMenuItem.Text = "Print Pre&view...";
        propertiesToolStripMenuItem.Text = "Properties";
        exitToolStripMenuItem.Text = "E&xit";

        //<snippet100>
        printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
        //</snippet100>

        saveAsToolStripMenuItem.Click +=
            new System.EventHandler(saveAsToolStripMenuItem_Click);
        pageSetupToolStripMenuItem.Click +=
            new System.EventHandler(pageSetupToolStripMenuItem_Click);
        printToolStripMenuItem.Click +=
            new System.EventHandler(printToolStripMenuItem_Click);
        printPreviewToolStripMenuItem.Click +=
            new System.EventHandler(printPreviewToolStripMenuItem_Click);
        propertiesToolStripMenuItem.Click +=
            new System.EventHandler(propertiesToolStripMenuItem_Click);
        exitToolStripMenuItem.Click +=
            new System.EventHandler(exitToolStripMenuItem_Click);

        toolStrip1.Items.AddRange(new ToolStripItem[] {
            goButton, backButton, forwardButton, stopButton,
            refreshButton, homeButton, searchButton, printButton});

        goButton.Text = "Go";
        backButton.Text = "Back";
        forwardButton.Text = "Forward";
        stopButton.Text = "Stop";
        refreshButton.Text = "Refresh";
        homeButton.Text = "Home";
        searchButton.Text = "Search";
        printButton.Text = "Print";

        backButton.Enabled = false;
        forwardButton.Enabled = false;

        goButton.Click += new System.EventHandler(goButton_Click);
        backButton.Click += new System.EventHandler(backButton_Click);
        forwardButton.Click += new System.EventHandler(forwardButton_Click);
        stopButton.Click += new System.EventHandler(stopButton_Click);
        refreshButton.Click += new System.EventHandler(refreshButton_Click);
        homeButton.Click += new System.EventHandler(homeButton_Click);
        searchButton.Click += new System.EventHandler(searchButton_Click);
        printButton.Click += new System.EventHandler(printButton_Click);

        toolStrip2.Items.Add(toolStripTextBox1);
        toolStripTextBox1.Size = new System.Drawing.Size(250, 25);
        toolStripTextBox1.KeyDown +=
            new KeyEventHandler(toolStripTextBox1_KeyDown);
        toolStripTextBox1.Click +=
            new System.EventHandler(toolStripTextBox1_Click);

        statusStrip1.Items.Add(toolStripStatusLabel1);

        webBrowser1.Dock = DockStyle.Fill;
        webBrowser1.Navigated +=
            new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);

        Controls.AddRange(new Control[] {
            webBrowser1, toolStrip2, toolStrip1, 
            menuStrip1, statusStrip1, menuStrip1 });
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}
//</Snippet0>
