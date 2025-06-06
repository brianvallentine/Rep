using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1 : QueryBasis<R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.COSSEGURO_PREMIOS
            VALUES (:COSSPREM-COD-EMPRESA ,
            :COSSPREM-TIPO-SEGURO ,
            :COSSPREM-COD-CONGENERE ,
            :COSSPREM-NUM-ORDEM ,
            :COSSPREM-NUM-APOLICE ,
            :COSSPREM-NUM-ENDOSSO ,
            :COSSPREM-NUM-PARCELA ,
            :COSSPREM-PRM-TARIFARIO-IX,
            :COSSPREM-VAL-DESCONTO-IX ,
            :COSSPREM-PRM-LIQUIDO-IX ,
            :COSSPREM-ADIC-FRACIO-IX ,
            :COSSPREM-VAL-COMISSAO-IX ,
            :COSSPREM-PRM-TOTAL-IX ,
            :COSSPREM-SIT-REGISTRO ,
            :COSSPREM-SIT-CONGENERE ,
            CURRENT TIMESTAMP ,
            :COSSPREM-OCORR-HISTORICO:VIND-OCR-HIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COSSEGURO_PREMIOS VALUES ({FieldThreatment(this.COSSPREM_COD_EMPRESA)} , {FieldThreatment(this.COSSPREM_TIPO_SEGURO)} , {FieldThreatment(this.COSSPREM_COD_CONGENERE)} , {FieldThreatment(this.COSSPREM_NUM_ORDEM)} , {FieldThreatment(this.COSSPREM_NUM_APOLICE)} , {FieldThreatment(this.COSSPREM_NUM_ENDOSSO)} , {FieldThreatment(this.COSSPREM_NUM_PARCELA)} , {FieldThreatment(this.COSSPREM_PRM_TARIFARIO_IX)}, {FieldThreatment(this.COSSPREM_VAL_DESCONTO_IX)} , {FieldThreatment(this.COSSPREM_PRM_LIQUIDO_IX)} , {FieldThreatment(this.COSSPREM_ADIC_FRACIO_IX)} , {FieldThreatment(this.COSSPREM_VAL_COMISSAO_IX)} , {FieldThreatment(this.COSSPREM_PRM_TOTAL_IX)} , {FieldThreatment(this.COSSPREM_SIT_REGISTRO)} , {FieldThreatment(this.COSSPREM_SIT_CONGENERE)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_OCR_HIST?.ToInt() == -1 ? null : this.COSSPREM_OCORR_HISTORICO))})";

            return query;
        }
        public string COSSPREM_COD_EMPRESA { get; set; }
        public string COSSPREM_TIPO_SEGURO { get; set; }
        public string COSSPREM_COD_CONGENERE { get; set; }
        public string COSSPREM_NUM_ORDEM { get; set; }
        public string COSSPREM_NUM_APOLICE { get; set; }
        public string COSSPREM_NUM_ENDOSSO { get; set; }
        public string COSSPREM_NUM_PARCELA { get; set; }
        public string COSSPREM_PRM_TARIFARIO_IX { get; set; }
        public string COSSPREM_VAL_DESCONTO_IX { get; set; }
        public string COSSPREM_PRM_LIQUIDO_IX { get; set; }
        public string COSSPREM_ADIC_FRACIO_IX { get; set; }
        public string COSSPREM_VAL_COMISSAO_IX { get; set; }
        public string COSSPREM_PRM_TOTAL_IX { get; set; }
        public string COSSPREM_SIT_REGISTRO { get; set; }
        public string COSSPREM_SIT_CONGENERE { get; set; }
        public string COSSPREM_OCORR_HISTORICO { get; set; }
        public string VIND_OCR_HIST { get; set; }

        public static void Execute(R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1 r2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1)
        {
            var ths = r2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}