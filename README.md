# LiquidTransformation
Library and program to be able to test Liquid transformations. Uses DotLiquid to perform the mapping.

Parameters for **LiquidTransform.exe**:


| Parameter        | Description           | Required  |
|:------------- |:-------------|:-----:|
| -t \| –template      | Full path to the Liquid template to use. | **Yes** |
| -c \| –content     | Full path to Content file.      |   **Yes**|
| -d \| –destination | Full path to destination file. Will overwrite an existing file  |   **Yes**|
| -r  –rootelement | Root element to add before render. For Logic Apps you will need to use **content** |   **No**|
| -u  \| –rubynaming| Use RubyNamingConvention, Logic Apps use C# naming conventions and will be the default.  |   **No**|
|  -?  \| -h  \| –help| Show help information   |   **No**|

**DotLiquid** Information  
Web site http://dotliquidmarkup.org  
Repository https://github.com/dotliquid/dotliquid  
Nuget package https://www.nuget.org/packages/DotLiquid/  

**Blog post**
https://skastberg.com/2019/01/20/test-your-liquid-transformations-without-deployment/

> Using DotLiquid version **2.2.656**
>
> **Note:** As per today the tool only accepts **JSON** as input document. When I wrote the tool I aimed for testing transformations I did in Logic Apps. I intentionally left that out as I could not mimic and get the same result as Microsofts code. You're more than welcome to contribute.

