# ChineseTranslationWebsite_ASP.NET_C-Sharp


## Project Background
In this project, you are going to develop atranslate website to translate
the text from Traditional Chinese to Simplified Chinese or vice versa.

## Project Requirements
• The web sites should provide a page, named Default.aspx, to perform the translation.
• The page should including at least the following components. You can have your own design of the layout.
• The web site only handles Unicode characters included in the given Unihan_STVariants.txt File (downloadable from Moodle).
• Each line of thefile lists a pieceof mapping fromonecharacter's Unicode code point to another code point.
• For example, the following line indicates that the character with code point 0x343D (㐽) is a simplified Chinese (becauseit has a traditional variant) and its corresponding traditional Chinese character is 0x5051 (偑). 
```
U+343D KTraditionalVariant U+5051
```
• The Web site only performs theconversion between individual characters, i.e., mappings between meaningful words/phrases are not considered. For example, 電腦 is simply converted to 电脑, not 计算机.
• If a simplified/traditional Chinese character can be converted to more than one counterpart, the web site will simply map it to the one with the largest code point. For example, 余 (U+4F59) is converted to 餘 (U+9918), not 余 (U+4F59). Similarly, 餘 (U+9918) is converted 馀 (U+9980), not 余 (U+4D59).
```
U+4F59 kTraditionalVariant U+4F59 U+9918
U+9918 kSimplifiedVariant U+4F59 U+9980
```
• You need download the data file Unihan_STVariants.txt from moodle and add it into your project folder. You must write program code to read the mapping data from this file and build your own mapping data structure before the user inputs. No database or other db-similar class (such as DataTable) is allowed.

## Program Design and Logic Flow
You need to follow the steps to do the conversion, you cannot make use of any library or existing functions to perform the direct conversion. You are required to write comments for your program and make sure your program runs well before your submission.
1. Read and extract the database file, and save it in the memory (i.e., array or list) for future use.
2. When convert button onClick, read the text from the textbox, and convert it to "UTF-32BE" byte string. You can make use of Encoding.getEncoding("UTF-32BE")to accomplish this.
3. Constructthe Unicode code point from the UTF32 byte code obtained in Step
4. Check the selectedIndex of the DropDownList and find the corresponding matching code point. fI there are multiple matching code point, we get the largest one.
5. Convert the code point that obtained in step 4 to UTF16-BE.
6. Convert the UTF16-BE byte string to string and present the result in the Output textbox.
```
byte[] result = intBytes;
String output = Encoding.GetEncoding("UTF-16BE").GetString (result);
```
