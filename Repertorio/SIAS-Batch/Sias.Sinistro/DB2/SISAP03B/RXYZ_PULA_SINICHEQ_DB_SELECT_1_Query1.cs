using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP03B
{
    public class RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 : QueryBasis<RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_OCORR_MOVTO
            INTO :GE100-NUM-OCORR-MOVTO
            FROM SEGUROS.GE_CONTROLE_INTERF_SAP A
            WHERE A.COD_IDLG = :GE100-COD-IDLG
            AND A.DTA_MOVIMENTO_LEGADO <> '9999-12-31'
            AND (
            EXISTS (SELECT 1
            FROM SEGUROS.GE_MOVDEBCE_SAP B
            WHERE B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
            OR
            EXISTS (SELECT 1
            FROM SEGUROS.GE_CHEQUE_SAP C
            WHERE C.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
            OR
            EXISTS (SELECT 1
            FROM SEGUROS.GE_BOLETO_RESSARC_SINI D
            WHERE D.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
            OR
            EXISTS (SELECT 1
            FROM SEGUROS.GE_VIDA_SAP E
            WHERE E.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
            OR
            EXISTS (SELECT 1
            FROM SEGUROS.GE_BOLETO_EMISSAO F
            WHERE F.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
            )
            ORDER BY A.DTA_MOVIMENTO_LEGADO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_OCORR_MOVTO
											FROM SEGUROS.GE_CONTROLE_INTERF_SAP A
											WHERE A.COD_IDLG = '{this.GE100_COD_IDLG}'
											AND A.DTA_MOVIMENTO_LEGADO <> '9999-12-31'
											AND (
											EXISTS
							(SELECT  1
											FROM SEGUROS.GE_MOVDEBCE_SAP B
											WHERE B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
											OR
											EXISTS
							(SELECT  1
											FROM SEGUROS.GE_CHEQUE_SAP C
											WHERE C.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
											OR
											EXISTS
							(SELECT  1
											FROM SEGUROS.GE_BOLETO_RESSARC_SINI D
											WHERE D.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
											OR
											EXISTS
							(SELECT  1
											FROM SEGUROS.GE_VIDA_SAP E
											WHERE E.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
											OR
											EXISTS
							(SELECT  1
											FROM SEGUROS.GE_BOLETO_EMISSAO F
											WHERE F.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO )
											)
											ORDER BY A.DTA_MOVIMENTO_LEGADO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE100_NUM_OCORR_MOVTO { get; set; }
        public string GE100_COD_IDLG { get; set; }

        public static RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 Execute(RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1)
        {
            var ths = rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE100_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}