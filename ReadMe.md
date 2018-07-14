## What I can do better : 
Model should be stand alone library. So Can be used by repo as we as Api and sevrvices. We can create standard model that would be returned by service like
{
Result:""
Error:""
    meta:{
        ResourcURI:"",
        }
}


## Technologies used: 
-Ef-60
-Web Api 2.0
-Swagger http://localhost:49840/swagger
-DI Unity   

## Url : http://localhost:49840/api/PaySlip
sample Input ;
{
  "FirstName": "Andrew",
  "LastName": "Smith",
  "AnualSalary": 60050,
  "SuperRate": 9,
  "PaymentStartDate": "01 March – 31 March"
}

sample output :
{
  "Name": "Andrew Smith",
  "PayPeriod": "01 March – 31 March",
  "GrossIncome": 5004,
  "IncomeTax": 922,
  "NetIncome": 4082,
  "SuperAmount": 450
}



