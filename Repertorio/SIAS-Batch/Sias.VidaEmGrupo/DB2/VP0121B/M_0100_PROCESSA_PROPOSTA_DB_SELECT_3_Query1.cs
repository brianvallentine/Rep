using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT 'S'
            INTO :WTEM-ERRO-7715
            FROM SEGUROS.ERROS_PROP_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND COD_ERRO IN (1866,1867,1868,1869,1870)
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT 'S'
											FROM SEGUROS.ERROS_PROP_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_ERRO IN (1866
							,1867
							,1868
							,1869
							,1870)
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string WTEM_ERRO_7715 { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1();
            var i = 0;
            dta.WTEM_ERRO_7715 = result[i++].Value?.ToString();
            return dta;
        }

    }
}