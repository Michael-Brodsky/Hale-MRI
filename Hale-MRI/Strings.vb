''' <summary>
''' Defines common string constants used throughout the application.
''' </summary>

Module Strings
    ' Constants for various string messages/user prompts used in the application
    Public Const STR_TITLE_DEFAULT As String = "Hale-MRI"
    Public Const STR_TITLE_APPLICATION_ERROR As String = "Application Error"
    Public Const STR_TITLE_ENCODER_ERROR As String = "Encoder Error"
    Public Const STR_TITLE_DATABASE_ERROR As String = "Database Error"
    Public Const STR_ERR_INVALID_SELECTION As String = "The selected item is not in the list. Please select a valid item."
    Public Const STR_ERR_CALIBRATION_DEFAULT As String = "Default"

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
End Module
