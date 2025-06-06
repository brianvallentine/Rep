using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1 : QueryBasis<M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :WS-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB = :VGSOLFAT-NUM-APOLICE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB = '{this.VGSOLFAT_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string WS_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1 Execute(M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1 m_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1)
        {
            var ths = m_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}