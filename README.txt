To obtain API credentials, follow these steps:

Go to the Google Cloud Console (console.cloud.google.com).
Select the project you want to use to access the Google Sheets API.
In the left navigation menu, click on "APIs & Services" > "Credentials".
Click on the "+ CREATE CREDENTIALS" button and select "OAuth client ID".
Select "Desktop App" as the application type.
Enter a name for your OAuth client ID, and click on the "CREATE" button.
On the next screen, click on "DOWNLOAD" to download the credentials as a JSON file.
Store the downloaded JSON file securely, as it contains sensitive information such as your client ID and client secret.

Please create a client_secret.json file with the following structure.


{
  "type": "service_account",
  "project_id": "vercelstorage",
  "private_key_id": "d1676289c18ee91baed693e2c1a07e2c5bb08213",
  "private_key": "key",
  "client_email": "csharp@vercelstorage.iam.gserviceaccount.com",
  "client_id": "117314093563009716530",
  "auth_uri": "https://accounts.google.com/o/oauth2/auth",
  "token_uri": "https://oauth2.googleapis.com/token",
  "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
  "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/csharp%40vercelstorage.iam.gserviceaccount.com"
}
