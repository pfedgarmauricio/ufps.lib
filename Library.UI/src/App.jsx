import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Dashboard from "./components/Dashboard";
import AuthorDetails from "./components/AuthorDetails";
import Nav from "./components/Nav";

function App() {
  return (
    <Router>
      <Nav />
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/author/:id" element={<AuthorDetails />} />
      </Routes>
    </Router>
  );
}

export default App;
