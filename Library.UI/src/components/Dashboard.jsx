import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import AddAuthorModal from "./AddAuthorModal"; 

const API_URL = "https://localhost:7223/api/Author";

const Dashboard = () => {
    const [authors, setAuthors] = useState([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        fetch(API_URL)
            .then((response) => response.json())
            .then((data) => {
                setAuthors(data);
                setLoading(false);
            })
            .catch((error) => console.error(error))
    }, []);

    const handleAuthorAdded = (newAuthor) => {
      setAuthors((prevAuthors) => [...prevAuthors, newAuthor]);
      setIsModalOpen(false);
    }

    const deleteAuthor = async (id) => {
      try {
        setLoading(true);
        const response = await fetch(`${API_URL}/${id}`, {
          method: "DELETE"
        });

        if (response.ok){
          setAuthors(authors.filter((author) => author.id !== id));
        } else {
          console.error("Failed.");
        }
      } catch (error) {
        console.error("Try catch error.");
      } finally {
        setLoading(false);
      }
    }

    if (loading) return <p className="text-center text-lg font-semibold">Loading...</p>;

    return (
      <div className="container p-10 max-w-6xl mx-auto w-4/5 flex flex-col items-center">
        <button className="fixed bottom-2 right-10 bg-blue-600 text-white w-12 h-12 rounded-full shadow-lg flex items-center justify-center text-2xl hover:bg-blue-700 transition"
          onClick={() => setIsModalOpen(true)}> + </button>

        <h1 className="text-4xl font-bold mb-8 text-center text-gray-800">Authors</h1>
        <div className="overflow-hidden shadow-lg rounded-lg w-full bg-white p-6">
          <table className="w-full border-collapse bg-white shadow-md rounded-lg overflow-hidden">
            <thead className="bg-blue-600 text-white">
              <tr>
                <th className="py-4 px-8 text-center">Name</th>
                <th className="py-4 px-8 text-center">Nationality</th>
                <th className="py-4 px-8 text-center">Date of Birth</th>
                <th className="py-4 px-8 text-center">Books</th>
                <th className="py-4 px-8 text-center">Delete</th>
              </tr>
            </thead>
            <tbody>
              {authors.length > 0 ? (
                authors.map((author, index) => (
                  <tr key={author.id} className={index % 2 === 0 ? "bg-gray-100" : "bg-white"}>
                    <td className="py-4 px-8 font-medium text-gray-800 text-center">{author.name}</td>
                    <td className="py-4 px-8 text-gray-600 text-center">{author.nationality}</td>
                    <td className="py-4 px-8 text-gray-500 text-center">{new Date(author.dateOfBirth).toLocaleDateString()}</td>
                    <td className="py-4 px-8 text-center">
                      <Link to={`/author/${author.id}`} className="text-blue-500 hover:underline">
                        View Books
                      </Link>
                    </td>
                    <td className="py-4 px-8 text-center">
                      <button onClick={() => deleteAuthor(author.id)}
                        className="bg-red-300 text-white w-6 h-6 rounded-full shadow-lg items-center justify-center hover:bg-red-400 transition">
                        X
                      </button>
                    </td>
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="4" className="py-4 text-center text-gray-500">No authors found.</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>

        {isModalOpen && (
          <AddAuthorModal 
            onClose={() => setIsModalOpen(false)} 
            onAuthorAdded={handleAuthorAdded} 
            API_URL={API_URL} 
          />
      )}
      </div>
    );
  }


export default Dashboard;