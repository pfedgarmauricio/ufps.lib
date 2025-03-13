import { useParams } from "react-router-dom";

const AuthorDetails = () => {
    const { id } = useParams();

    return (
        <div className="container">
            Author... {id}
        </div>
    );
}

export default AuthorDetails;