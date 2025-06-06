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
    public class M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT CODRELAT,
            IDSISTEM
            INTO :RELAT-CODRELAT:RELAT-CODRELAT-I,
            :RELAT-IDSISTEM
            FROM
            SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :MOVTO-NUM-APOLICE
            AND CODSUBES = :MOVTO-COD-SUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODRELAT
							,
											IDSISTEM
											FROM
											SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.MOVTO_NUM_APOLICE}'
											AND CODSUBES = '{this.MOVTO_COD_SUBES}'
											WITH UR";

            return query;
        }
        public string RELAT_CODRELAT { get; set; }
        public string RELAT_CODRELAT_I { get; set; }
        public string RELAT_IDSISTEM { get; set; }
        public string MOVTO_NUM_APOLICE { get; set; }
        public string MOVTO_COD_SUBES { get; set; }

        public static M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1 Execute(M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1 m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = m_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELAT_CODRELAT = result[i++].Value?.ToString();
            dta.RELAT_CODRELAT_I = string.IsNullOrWhiteSpace(dta.RELAT_CODRELAT) ? "-1" : "0";
            dta.RELAT_IDSISTEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}