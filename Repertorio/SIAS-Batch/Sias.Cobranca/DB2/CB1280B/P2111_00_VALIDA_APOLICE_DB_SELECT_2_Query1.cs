using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1 : QueryBasis<P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WS-QT-REGISTRO-1
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'
											AND COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											WITH UR";

            return query;
        }
        public string WS_QT_REGISTRO_1 { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1 Execute(P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1 p2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1)
        {
            var ths = p2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_QT_REGISTRO_1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}