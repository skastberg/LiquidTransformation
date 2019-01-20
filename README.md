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


