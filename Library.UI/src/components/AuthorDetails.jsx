import { useParams } from "react-router-dom";

const AuthorDetails = () => {
    const { ID } = useParams();

    return (
        <div>
            Author... {ID}
        </div>
    );
}

export default AuthorDetails;