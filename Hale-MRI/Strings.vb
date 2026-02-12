''' <summary>
''' Defines common string constants used throughout the application.
''' </summary>
Module Strings
    ' Constants for various string messages/user prompts used in the application
    Public Const STR_TITLE_DEFAULT As String = "Hale-MRI"
    Public Const STR_TITLE_APPLICATION_ERROR As String = "Application Error"
    Public Const STR_TITLE_ENCODER_ERROR As String = "Encoder Error"
    Public Const STR_TITLE_DATABASE_ERROR As String = "Database Error"

    Public Const STR_ERR_ADDNEW As String = "Error adding new {0}: {1}"
    Public Const STR_ERR_CALIBRATION_DEFAULT As String = "Default"
    Public Const STR_ERR_FILE_OPEN As String = "Error opening the {0} file: {1}"
    Public Const STR_ERR_FORM_OPEN As String = "Error opening the {0} form: {1}"
    Public Const STR_ERR_INVALID_SELECTION As String = "The selected item is not in the list. Please select a valid item."
    Public Const STR_ERR_NAVIGATION As String = "Navigation error: {0}"
    Public Const STR_ERR_NO_DEFAULT_VALUE As String = "Error no default value: {0}"
    Public Const STR_ERR_OBJECT_LOAD As String = "Error loading the {0}: {1}"

    Public Const STR_PROMPT_UNSAVED_CHANGES As String = "There are unsaved changes. Do you want to save them?"

    ' String parameters for functions.
    Public Const STR_PARAM_DECIMAL_PLACES As String = "F2"  ' This is a ~Settings parameter in dB.

    ' Setting names used in ~Settings table.
    Public Const STR_SETTING_COMPANY_NAME As String = "Company Name"
    Public Const STR_SETTING_COMPANY_ADDRESS As String = "Company Address"
    Public Const STR_SETTING_COMPANY_PHONE As String = "Company Phone"
    Public Const STR_SETTING_COMPANY_CONTACT As String = "Company Contact"
    Public Const STR_SETTING_COMPANY_EMAIL As String = "Company Email"
    Public Const STR_SETTING_COMPANY_WEBSITE As String = "Company Website"
    Public Const STR_SETTING_APPLICATION_DEFAULT_FOLDER As String = "Application Default Folder"
    Public Const STR_SETTING_DATABASE_FILE As String = "Application Database File"
    Public Const STR_SETTING_DATABASE_CONNECTION_STRING As String = "Application Connection String"
    Public Const STR_SETTING_ENCODER_DATA_DEFAULT_FOLDER As String = "Encoder Data Default Folder"
    Public Const STR_SETTING_ENCODER_DEFAULT_SAMPLE_PERIOD As String = "Encoder Default Sample Interval"
    Public Const STR_SETTING_ENCODER_MAX_SAMPLES_PER_SCAN As String = "Encoder Max Samples Per Scan"

    ' File dialog filter strings.
    Public Const STR_DIALOG_FILTER_ALL As String = "All Files (*.*)|*.*"
    Public Const STR_DIALOG_FILTER_CSV As String = "CSV Files |*.csv;*.txt|All Files (*.*)|*.*"
    Public Const STR_DIALOG_FILTER_DATABASE As String = "Database Files|*.mdb;*.accdb;*.sqlite;*.db|All Files (*.*)|*.*"
    Public Const STR_DIALOG_FILTER_IMAGE As String = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*"
    Public Const STR_DIALOG_FILTER_SCANDATA As String = "ScanData Files (*.txt)|*.txt|All Files (*.*)|*.*"
    Public Const STR_DIALOG_FILTER_TEXT As String = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
End Module
