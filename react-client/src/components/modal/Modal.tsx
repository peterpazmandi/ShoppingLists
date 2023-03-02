import { useContext } from "react";
import { ModalContext } from "./context/modalContext";
import { ModalContextType } from "./type/modelContext.type";

const Modal = () => {
    const { closeModal } = useContext(ModalContext) as ModalContextType;
    
    return (
        <aside className="modal-overlay">
            <div className="modal-container">
                <div className="modal-content">
                    <h4>title</h4>
                    <p>Cooking Instructions</p>
                    <p>text</p>
                    <button onClick={closeModal}>Test</button>
                </div>
            </div>
        </aside>
    )
}

export default Modal;