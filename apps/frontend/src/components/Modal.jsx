import PropTypes from 'prop-types';
import { FaTimes } from 'react-icons/fa';

function Modal({ isVisible, onClose, children, width = 'max-w-2xl', height = 'h-auto' }) {
  if (!isVisible) return null;

  return (
    <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50 p-5">
      <div
        className={`bg-white rounded-lg shadow-lg relative ${width} ${height} w-full flex flex-col p-6`}
      >
        <button
          onClick={onClose}
          className="absolute top-3 right-3 text-neutral-950 hover:text-blue-800 text-xl cursor-pointer"
        >
          <FaTimes />
        </button>
        {children}
      </div>
    </div>
  );
}

Modal.propTypes = {
  isVisible: PropTypes.bool.isRequired,
  onClose: PropTypes.func.isRequired,   
  children: PropTypes.node.isRequired,
  width: PropTypes.string,
  height: PropTypes.string,
};

export default Modal;
