public class FileSystem
{
 private class Node
 {
 public string directory;
 public List<string> file = new List<string>();
 public Node leftMostChild;
 public Node rightSibling;
 

 }


 private Node root;
 // Creates a file system with a root directory where the name of the root directory is “/”.
 public FileSystem( ) {



 }
 // Adds a file at the given address
 // Returns false if the file already exists at that address or the path is undefined; true otherwise
 public bool AddFile(string address) { 


return true;

  }
 // Removes the file at the given address
 // Returns false if the file is not found at that address or the path is undefined; true otherwise
 public bool RemoveFile(string address) { 

    Boolean isHere = false;

    if(!address.Contains("file")){
        return isHere;
    }
    else{
       for(int i = 0; i<= address.Length; i++){
        address.Remove(i);
        return isHere = true;

       }
    }

    return isHere;
    
  }
 // Adds a directory at the given address
 // Returns false if the directory already exists or the path is undefined; true otherwise
 public bool AddDirectory(string address) { 

    return true;
  }
 // Removes the directory (and its subdirectories) at the given address
 // Returns false if the directory is not found or the path is undefined; true otherwise
 public bool RemoveDirectory(string address) { 

    return false;
  }
 // Returns the number of files in the file system (Do not add a count as a data member)
 public int NumberFiles( ) { 

    return 1;

  }
 // Prints the directories in a pre-order fashion along with their files
 public void PrintFileSystem( ) { 

 }
}
