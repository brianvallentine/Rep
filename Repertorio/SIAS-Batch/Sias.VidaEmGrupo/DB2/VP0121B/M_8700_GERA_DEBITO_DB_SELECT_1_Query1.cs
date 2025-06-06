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
    public class M_8700_GERA_DEBITO_DB_SELECT_1_Query1 : QueryBasis<M_8700_GERA_DEBITO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO,
            COD_CONV_CARTAO
            INTO :CONVEN-CODCONV,
            :CONVEN-CARTAO
            FROM SEGUROS.V0CONVENIOSVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
							,
											COD_CONV_CARTAO
											FROM SEGUROS.V0CONVENIOSVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											WITH UR";

            return query;
        }
        public string CONVEN_CODCONV { get; set; }
        public string CONVEN_CARTAO { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_8700_GERA_DEBITO_DB_SELECT_1_Query1 Execute(M_8700_GERA_DEBITO_DB_SELECT_1_Query1 m_8700_GERA_DEBITO_DB_SELECT_1_Query1)
        {
            var ths = m_8700_GERA_DEBITO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8700_GERA_DEBITO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8700_GERA_DEBITO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVEN_CODCONV = result[i++].Value?.ToString();
            dta.CONVEN_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}