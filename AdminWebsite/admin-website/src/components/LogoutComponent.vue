<script>
import { auth } from "@/firebaseconfig";

export default {
    name: 'LogoutComponent',
    created() {
        this.logout()
    },
    
    methods: {
     
        async logout() 
        {
              await auth.signOut()
        }
    }
}
</script>
