using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0410B
{
    public class M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1 : QueryBasis<M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            CODSUBES
            INTO :RELAT-NUM-APOLICE,
            :RELAT-COD-SUBES
            FROM SEGUROS.COBRANCA_MENS_VGAP
            WHERE IDFORM = 'A4'
            AND NUM_APOLICE = :MOVTO-NUM-APOLICE
            AND CODSUBES = :MOVTO-COD-SUBES
            AND COD_OPERACAO = 2
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											CODSUBES
											FROM SEGUROS.COBRANCA_MENS_VGAP
											WHERE IDFORM = 'A4'
											AND NUM_APOLICE = '{this.MOVTO_NUM_APOLICE}'
											AND CODSUBES = '{this.MOVTO_COD_SUBES}'
											AND COD_OPERACAO = 2
											WITH UR";

            return query;
        }
        public string RELAT_NUM_APOLICE { get; set; }
        public string RELAT_COD_SUBES { get; set; }
        public string MOVTO_NUM_APOLICE { get; set; }
        public string MOVTO_COD_SUBES { get; set; }

        public static M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1 Execute(M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1 m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1)
        {
            var ths = m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.RELAT_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELAT_COD_SUBES = result[i++].Value?.ToString();
            return dta;
        }

    }
}