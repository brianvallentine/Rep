using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1 : QueryBasis<R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.EMISSAO_DIARIA
            ( COD_RELATORIO
            , NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , DATA_MOVIMENTO
            , ORGAO_EMISSOR
            , RAMO_EMISSOR
            , COD_FONTE
            , COD_CONGENERE
            , COD_CORRETOR
            , SIT_REGISTRO
            , COD_EMPRESA
            , TIMESTAMP)
            VALUES ( 'AU2060B3'
            , :CBAPOVIG-NUM-APOLICE
            , :CBAPOVIG-NUM-ENDOSSO
            , 0
            , :SISTEMAS-DATA-MOV-ABERTO
            , 0
            , :APOLICES-RAMO-EMISSOR
            , :ENDOSSOS-COD-FONTE
            , 0
            , 0
            , 0
            , 0
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.EMISSAO_DIARIA ( COD_RELATORIO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_MOVIMENTO , ORGAO_EMISSOR , RAMO_EMISSOR , COD_FONTE , COD_CONGENERE , COD_CORRETOR , SIT_REGISTRO , COD_EMPRESA , TIMESTAMP) VALUES ( 'AU2060B3' , {FieldThreatment(this.CBAPOVIG_NUM_APOLICE)} , {FieldThreatment(this.CBAPOVIG_NUM_ENDOSSO)} , 0 , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 0 , {FieldThreatment(this.APOLICES_RAMO_EMISSOR)} , {FieldThreatment(this.ENDOSSOS_COD_FONTE)} , 0 , 0 , 0 , 0 , CURRENT TIMESTAMP)";

            return query;
        }
        public string CBAPOVIG_NUM_APOLICE { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }

        public static void Execute(R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1 r5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1)
        {
            var ths = r5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_INCLUI_REGISTRO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}