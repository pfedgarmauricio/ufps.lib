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

    if (loading) return <p className="text-center text-lg font-semibold">Loading...</p>;

    return (
      <div className="p-10 max-w-6xl mx-auto w-4/5 flex flex-col items-center">
        <button className="fixed bottom-2 right-10 bg-blue-600 text-white w-12 h-12 rounded-full shadow-lg flex items-center justify-center text-2xl hover:bg-blue-700 transition"
          onClick={() => setIsModalOpen(true)}> + </button>

        <h1 className="text-4xl font-bold mb-8 text-center text-gray-800">Authors</h1>
        <div className="overflow-hidden shadow-lg rounded-lg w-full bg-white p-6">
          <table className="w-full border-collapse bg-white shadow-md rounded-lg overflow-hidden">
            <thead className="bg-blue-600 text-white">
              <tr>
                <th className="py-4 px-8 text-left">Name</th>
                <th className="py-4 px-8 text-left">Nationality</th>
                <th className="py-4 px-8 text-left">Date of Birth</th>
                <th className="py-4 px-8 text-left">Actions</th>
              </tr>
            </thead>
            <tbody>
              {authors.length > 0 ? (
                authors.map((author, index) => (
                  <tr key={author.id} className={index % 2 === 0 ? "bg-gray-100" : "bg-white"}>
                    <td className="py-4 px-8 font-medium text-gray-800">{author.name}</td>
                    <td className="py-4 px-8 text-gray-600">{author.nationality}</td>
                    <td className="py-4 px-8 text-gray-500">{new Date(author.dateOfBirth).toLocaleDateString()}</td>
                    <td className="py-4 px-8">
                      <Link to={`/author/${author.id}`} className="text-blue-500 hover:underline">
                        View Books
                      </Link>
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