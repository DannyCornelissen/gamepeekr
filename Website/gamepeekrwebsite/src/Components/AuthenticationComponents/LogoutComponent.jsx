import {signOut} from "firebase/auth";
import { auth } from "../../Utils/firebase.utils";


const SignOutUser = async () =>
{  
    try
    {
        console.log(auth.currentUser)
        await signOut(auth)
        console.log(auth.currentUser)
    }  
    catch
    {

    }
}
export default SignOutUser;