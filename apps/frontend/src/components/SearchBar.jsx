import PropTypes from "prop-types";
import { CiSearch } from "react-icons/ci";
import Button from "./Button";
import { useState } from "react";

export default function SearchBar({ onSearch }) {
  const [text, setText] = useState("");

  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      onSearch(text);
      setText("");
    }
  };

  const handleClick = () => {
    onSearch(text);
    setText("");
  };

  return (
    <div className="flex justify-between items-center border-2 border-[#E5E5E5] bg-white rounded-[10px] w-full p-2">
      <input
        type="text"
        placeholder="Search..."
        value={text}
        onChange={(e) => {
          setText(e.target.value);
        }}
        onKeyUp={handleKeyPress}
        className="flex-grow p-2 border-none focus:ring-0"
      />
      <Button onClick={handleClick}>
        <CiSearch className="size-[20px]" />
      </Button>
    </div>
  );
}

SearchBar.propTypes = {
  onSearch: PropTypes.func,
};
