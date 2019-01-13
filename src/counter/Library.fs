

module api.Count
    let mutable count = 0
    
    let inc () =
        count <- count + 1
     
    let getValue () = 
        count
    

