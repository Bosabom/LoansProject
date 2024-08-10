import { useRef } from "react";
import Form, { FormHandle } from "../components/UI/Form";
import Input from "../components/UI/Input";
import Button from "../components/UI/Button";

export default function NewTemplatePage(){
    
    const form = useRef<FormHandle>(null);
    function handleSaveNewTemplate(data: unknown) {
        const extractedData = data as { templateName: string; templateJSON: string };
        //TODO: call POST method and save data
        console.log(extractedData);
        form.current?.clear();
      }

    return(        
        <Form ref={form} onSave={handleSaveNewTemplate} id="add-template">
            <h4>New Template</h4>
            <Input id="template-name" name="templatename" type="text" label="" 
            required maxLength={1000} placeholder="Template Name" />
            {/* <Input type="text" label="Template Json" id="template-json" /> */}
            
            <div>
                <textarea name="template json" id="template-json" placeholder="Template JSON" rows={8}></textarea>
            </div>  
            <p>
                <Button>Save</Button>
                <Button>Cancel</Button>
            </p>
            
        </Form>
    );
}