using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1 : QueryBasis<R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.PARCELA_AUTO_COMPL
            VALUES (:AU071-NUM-APOLICE ,
            :AU071-NUM-ENDOSSO ,
            :AU071-NUM-PARCELA ,
            :AU071-DTA-VENCTO ,
            :AU071-NUM-VENCTO ,
            :AU071-VLR-PREMIO-LIQUIDO ,
            :AU071-VLR-JUROS ,
            :AU071-VLR-ADIC-FRAC ,
            :AU071-VLR-MULTA ,
            :AU071-VLR-CUSTO ,
            :AU071-VLR-IOF ,
            :AU071-VLR-PREMIO-TOTAL ,
            :AU071-NUM-RECIBO-CONV ,
            'EM0010B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELA_AUTO_COMPL VALUES ({FieldThreatment(this.AU071_NUM_APOLICE)} , {FieldThreatment(this.AU071_NUM_ENDOSSO)} , {FieldThreatment(this.AU071_NUM_PARCELA)} , {FieldThreatment(this.AU071_DTA_VENCTO)} , {FieldThreatment(this.AU071_NUM_VENCTO)} , {FieldThreatment(this.AU071_VLR_PREMIO_LIQUIDO)} , {FieldThreatment(this.AU071_VLR_JUROS)} , {FieldThreatment(this.AU071_VLR_ADIC_FRAC)} , {FieldThreatment(this.AU071_VLR_MULTA)} , {FieldThreatment(this.AU071_VLR_CUSTO)} , {FieldThreatment(this.AU071_VLR_IOF)} , {FieldThreatment(this.AU071_VLR_PREMIO_TOTAL)} , {FieldThreatment(this.AU071_NUM_RECIBO_CONV)} , 'EM0010B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string AU071_NUM_APOLICE { get; set; }
        public string AU071_NUM_ENDOSSO { get; set; }
        public string AU071_NUM_PARCELA { get; set; }
        public string AU071_DTA_VENCTO { get; set; }
        public string AU071_NUM_VENCTO { get; set; }
        public string AU071_VLR_PREMIO_LIQUIDO { get; set; }
        public string AU071_VLR_JUROS { get; set; }
        public string AU071_VLR_ADIC_FRAC { get; set; }
        public string AU071_VLR_MULTA { get; set; }
        public string AU071_VLR_CUSTO { get; set; }
        public string AU071_VLR_IOF { get; set; }
        public string AU071_VLR_PREMIO_TOTAL { get; set; }
        public string AU071_NUM_RECIBO_CONV { get; set; }

        public static void Execute(R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1 r7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1)
        {
            var ths = r7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}