       IDENTIFICATION DIVISION.                                                 
       PROGRAM-ID. AC10P013.                                                    
                                                                                
      *---------------------*                                                   
       ENVIRONMENT DIVISION.                                                    
      *---------------------*                                                   
                                                                                
      *---------------------*                                                   
       CONFIGURATION SECTION.                                                   
      *---------------------*                                                   
                                                                                
      *-------------*                                                           
       SPECIAL-NAMES.                                                           
      *-------------*                                                           
           DECIMAL-POINT IS COMMA.                                              
                                                                                
      *--------------------*                                                    
       INPUT-OUTPUT SECTION.                                                    
      *--------------------*                                                    
                                                                                
      *-------------*                                                           
       DATA DIVISION.                                                           
      *-------------*                                                           
      *                                                                         
      *-----------------------*                                                 
       WORKING-STORAGE SECTION.                                                 
      *-----------------------*                                                 
             
      *----------------------------------------------------------------*        
      *- VARIAVEIS AUXILIARES                                          *        
      *----------------------------------------------------------------*        
                                                                                     
      *>    05  LK-TIP-CALC                        PIC 9(001) VALUE ZEROS .            
      *>    05  LK-NUM-APOL                        PIC 9(001) VALUE ZEROS .           
      *>    05  LK-NRENDOS                         PIC 9(001) VALUE ZEROS .   
      *>    05  LK-DTINIVIG                     OCCURS      2000   TIMES               
      *>                                        INDEXED      BY    WIND.          
      *>        10      WTABG-CODPRODU             PIC S9(004)        COMP.               
      *>            15  WTABG-OCORRETIP         OCCURS       003   TIMES       
      *>                                        INDEXED      BY    WIND2.     
      *>                25    WTABG-TIPO  PIC  X(001).                 

      *>   77  LK-TIP-CALC                        PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  COD-CLIENTE                        PIC X(254).
           77  NUM-ITEM                           PIC X(254).
           77  COD-MODALIDADE                     PIC X(254).
           77  ORGAO-EMISSOR                      PIC X(254).
           77  RAMO-EMISSOR                       PIC X(254).
           77  COD-PRODUTO                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
    COD-CLIENTE
       NUM-ITEM
 COD-MODALIDADE
  ORGAO-EMISSOR
   RAMO-EMISSOR
    COD-PRODUTO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT COD_CLIENTE, NUM_APOLICE, NUM_ITEM, COD_MODALIDADE, ORGAO_EMISSOR, RAMO_EMISSOR, COD_PRODUTO FROM seguros.apolices WHERE NUM_APOLICE = :NUM_APOLICE END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
