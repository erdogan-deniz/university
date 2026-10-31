import easyocr

# OUTPUT RESULT IN CONSOLE:
def text_recognition(file_path):
    reader = easyocr.Reader(["ru"])
    result = reader.readtext(file_path, detail=0, paragraph=True)

    return  result

# OUTPUT RESULT IN FILE:
#def text_recognition(file_path, text_file_name="result.txt"):
#    reader = easyocr.Reader(["ru"])
#    result = reader.readtext(file_path, detail=0, paragraph=True)
#
#    with open(text_file_name, 'w') as file:
#        for line in result:
#            file.write(f"{line}\n\n")
#
#    return f"Result was wrote into {text_file_name}"

def main():
    file_path = input("Input file: ")
    #new_file_name = input("Input name of result file: ")
    #text_recognition(file_path=file_path, text_file_name=new_file_name)

    # FOR CONSOLE OUTPUT:
    lst = text_recognition(file_path=file_path)

    for i in lst:
        print(i)

if __name__ == "__main__":
    main()