How to build
* `dotnet build`
* `dotnet publish`

How to run (windows)
* run command `dotnet run`
* alternatively `GA\DS\bin\debug\net6.0\publish\DS.exe`

How to run (linux)
* `dotnet GA\DS\bin\debug\net6.0\publish\DS.dll`

Input
* Drive path to scan on first arg on command line
* alternatively no args and user input

Output
* output.txt

General assumptions
* files not in use
* line number is sufficient for finding one but maybe not more than one match

CC assumptions
* Regex only covers partial (some specific and branded) CC#s. Intent to expand.
* CC regex for formatting, validation library as a second step.

CC regex
(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})
Source: 

SSN assumptions
* It should have 9 digits.
* It should be divided into 3 parts by hyphen (-).
* The first part should have 3 digits and should not be 000, 666, or between 900 and 999.
* The second part should have 2 digits and it should be from 01 to 99.
* The third part should have 4 digits and it should be from 0001 to 9999.

SSN regex
(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}
Source: https://www.geeksforgeeks.org/how-to-validate-ssn-social-security-number-using-regular-expression/

External 3rd Party Libraries
* Serilog - logging library I leveraged for output and context
https://github.com/serilog/serilog

* CreditCardValidator - library I found on Github to not have to implement a CC# algo
https://github.com/gustavofrizzo/CreditCardValidator



CC Validation
https://www.geeksforgeeks.org/program-credit-card-number-validation/
https://stackoverflow.com/a/23231321/697827
https://www.regular-expressions.info/creditcard.html
https://stackoverflow.com/a/9315696/697827


MSDN Method vs Directory.GetFiles
Stack overflow recursive vs infinite loop in folder structure
https://stackoverflow.com/questions/4254339/how-to-loop-through-all-the-files-in-a-directory-in-c-net
