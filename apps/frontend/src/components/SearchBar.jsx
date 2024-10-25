import { CiSearch } from 'react-icons/ci';
import Button from './Button';

export default function SearchBar() {
  return (
    <div className="flex justify-between items-center border-2 border-[#E5E5E5] bg-white rounded-[10px] w-full p-2">
      <input 
        type="text" 
        placeholder="Search..." 
        className="flex-grow p-2 border-none focus:ring-0"
      />
      <Button>
        <CiSearch className="size-[20px]" />
      </Button>
    </div>
  );
}
