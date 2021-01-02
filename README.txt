In order to correctly test this project please use the user properties provided in this document.
Some user information has been setup to be preseeded into the database when this solution is made to run on your machine for the first time.
These can be used to signin and test the system without having to signup a new user. This is useful as it prevents issues arising from errors due to inputs.

These users are preseeded:

FirstName="Segun"
LastName="Adaramaja"
Email="seguna@gmail.com"
UserName="seguna@gmail.com"
PhoneNumber="08095784765"
Password="P@$$word1"

******************************
FirstName="Seun"
LastName="Oyetoyan"
Email="seuno@gmail.com"
UserName="seuno@gmail.com"
PhoneNumber="07057893783"
Password="P@$$word1"

******************************
FirstName="Micheal"
LastName="Nwosu"
Email="miken@gmail.com"
UserName="miken@gmail.com"
PhoneNumber="08036754890"
Password="P@$$word1"

IMPORTANT: 1. To correctly run this solution, the EmployeeRecordsAPI project must be run first.
	   2. In order to signup a new user, the password must contain the following:
		A. an uppercase alphabetic character
		B. a lowercase alphabetic character
		C. a special character(eg. $ or ! etc)
		D. a numeric character
		E. between 8 and 15 characters.
		

STEP 1: Right click on the EmployeeRecordsAPI project in the Solution Explorer. Select "Start New Instance" under the "Debug" flyout menu.
This should run http://localhost:5000/api/auth on a browser window.

STEP 2: Right click on the HumanResourceSystem project in the Solution Explorer. Select "Start New Instance" under the "Debug" flyout menu.
This should run https://localhost:44313/ on a browser window. Note, you can create several more instances of this system by visiting the link on a new window.

STEP 3: Right click on the AccountingSystem project in the Solution Explorer. Select "Start New Instance" under the "Debug" flyout menu.
This should run https://localhost:44381/ on a browser window. Note, you can create several more instances of this system by visiting the link on a new window.

STEP 4: On both the open Accounting and the Human Resource Systems, sign up a new user by clicking on the "Sign Up" button or click the "Sign In" button to sign in with the email and password of any of the preseeded users listed above.
This should redirect you to the Chat Room on either System.

STEP 5: To send a broadcast message to all logged in users, enter the sender's name and the message to be broadcasted.
This should send a message to every logged in user.

STEP 6: To send a message to a single user, copy the target recipient's ConnID. A user's ConnID(connection Id) is their unique identifier and can be found under the "CHAT ROOM" header.
Paste the ConnID into the sender's "To" input box and enter the sender's name and message. This should send the target user a private message.

STEP 7: Click the "Log Out" button to log out a user.