using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1 : QueryBasis<R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.AU_PROP_COBRNCA_VC
            ( NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            SEQ_HISTORICO ,
            OCORR_HISTORICO ,
            COD_OPERACAO ,
            VLR_PARCELA ,
            DTH_MOVIMENTO ,
            DTH_VENCTO_REPROG ,
            NUM_ARQUIVO ,
            DTH_CADASTRAMENTO ,
            COD_CONGENERE)
            VALUES (:AU050-NUM-APOLICE ,
            :AU050-NUM-ENDOSSO ,
            :AU050-NUM-PARCELA ,
            :AU050-SEQ-HISTORICO ,
            :AU050-OCORR-HISTORICO ,
            :AU050-COD-OPERACAO ,
            :AU050-VLR-PARCELA ,
            :AU050-DTH-MOVIMENTO ,
            NULL ,
            :AU050-NUM-ARQUIVO ,
            CURRENT TIMESTAMP,
            :AU050-COD-CONGENERE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AU_PROP_COBRNCA_VC ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SEQ_HISTORICO , OCORR_HISTORICO , COD_OPERACAO , VLR_PARCELA , DTH_MOVIMENTO , DTH_VENCTO_REPROG , NUM_ARQUIVO , DTH_CADASTRAMENTO , COD_CONGENERE) VALUES ({FieldThreatment(this.AU050_NUM_APOLICE)} , {FieldThreatment(this.AU050_NUM_ENDOSSO)} , {FieldThreatment(this.AU050_NUM_PARCELA)} , {FieldThreatment(this.AU050_SEQ_HISTORICO)} , {FieldThreatment(this.AU050_OCORR_HISTORICO)} , {FieldThreatment(this.AU050_COD_OPERACAO)} , {FieldThreatment(this.AU050_VLR_PARCELA)} , {FieldThreatment(this.AU050_DTH_MOVIMENTO)} , NULL , {FieldThreatment(this.AU050_NUM_ARQUIVO)} , CURRENT TIMESTAMP, {FieldThreatment(this.AU050_COD_CONGENERE)})";

            return query;
        }
        public string AU050_NUM_APOLICE { get; set; }
        public string AU050_NUM_ENDOSSO { get; set; }
        public string AU050_NUM_PARCELA { get; set; }
        public string AU050_SEQ_HISTORICO { get; set; }
        public string AU050_OCORR_HISTORICO { get; set; }
        public string AU050_COD_OPERACAO { get; set; }
        public string AU050_VLR_PARCELA { get; set; }
        public string AU050_DTH_MOVIMENTO { get; set; }
        public string AU050_NUM_ARQUIVO { get; set; }
        public string AU050_COD_CONGENERE { get; set; }

        public static void Execute(R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1 r7040_00_INCLUI_AU050_DB_INSERT_1_Insert1)
        {
            var ths = r7040_00_INCLUI_AU050_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}