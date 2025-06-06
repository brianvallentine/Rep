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
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :PROPOFID-NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8_Query1();
            var i = 0;
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}