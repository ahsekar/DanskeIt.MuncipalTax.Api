# DanskeIt.MuncipalTax.Api
Muncipal Tax calculation

Assumptions: daily tax have been considered with more priority. Then followed by weekly, monthly and yearly with yearly have the least priority.
If the date supplied falls in daily tax that amount will be returned from API eventhough if same date is present in yearly tax.

The format in which we can send values to API is JSON. Sample json has been provided in the project.

# For Database Side
Instead of using Database used In memory cache for storing tax values.
WHen application starts make sure to call the POST end point and then the GET end point
