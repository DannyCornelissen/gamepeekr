
<script>
import { signInWithPopup, GoogleAuthProvider } from "firebase/auth";
import { auth } from "@/firebaseconfig";

export default {
    name: "SignUp",
    created() {
        this.googleSignIn();
    },
    methods: {
        googleSignIn: async function() {
            let provider = new GoogleAuthProvider();

            provider.setCustomParameters({
                prompt: "select_account"
            });

            await signInWithPopup(auth, provider).then(() => {
                // Redirect to desired page after sign in
                this.$router.push("/");
            }).catch((err) => {
                console.log(err);
            });
        }
    }
};
</script>
