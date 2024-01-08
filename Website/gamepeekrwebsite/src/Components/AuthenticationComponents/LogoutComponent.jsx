import {signOut} from "firebase/auth";
import { auth } from "../../Utils/firebase.utils";


const SignOutUser = async () =>
{  
    try
    {
        await signOut(auth)
    }  
    catch
    {

    }
}
export default SignOutUser;