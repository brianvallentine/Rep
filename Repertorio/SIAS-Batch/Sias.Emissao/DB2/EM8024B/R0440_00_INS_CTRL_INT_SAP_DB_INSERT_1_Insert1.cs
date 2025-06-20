using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1 : QueryBasis<R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_CONTROLE_INTERF_SAP
            ( NUM_OCORR_MOVTO
            , COD_IDLG
            , DTA_MOVIMENTO_LEGADO
            , DTH_GERACAO_LEGADO
            , DTH_GERACAO_ARQA
            , COD_IDE_PAGTO_SAP
            , COD_IDE_RECEBE_SAP
            , DTH_PROCESSA_ARQG
            , IND_ACEITE_SAP
            , DTA_MOVIMENTO_ARQH
            )
            VALUES ( :GE100-NUM-OCORR-MOVTO
            , :GE100-COD-IDLG
            , :GE100-DTA-MOVIMENTO-LEGADO
            , CURRENT TIMESTAMP
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , :GE100-DTA-MOVIMENTO-ARQH)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CONTROLE_INTERF_SAP ( NUM_OCORR_MOVTO , COD_IDLG , DTA_MOVIMENTO_LEGADO , DTH_GERACAO_LEGADO , DTH_GERACAO_ARQA , COD_IDE_PAGTO_SAP , COD_IDE_RECEBE_SAP , DTH_PROCESSA_ARQG , IND_ACEITE_SAP , DTA_MOVIMENTO_ARQH ) VALUES ( {FieldThreatment(this.GE100_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE100_COD_IDLG)} , {FieldThreatment(this.GE100_DTA_MOVIMENTO_LEGADO)} , CURRENT TIMESTAMP , NULL , NULL , NULL , NULL , NULL , {FieldThreatment(this.GE100_DTA_MOVIMENTO_ARQH)})";

            return query;
        }
        public string GE100_NUM_OCORR_MOVTO { get; set; }
        public string GE100_COD_IDLG { get; set; }
        public string GE100_DTA_MOVIMENTO_LEGADO { get; set; }
        public string GE100_DTA_MOVIMENTO_ARQH { get; set; }

        public static void Execute(R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1 r0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}