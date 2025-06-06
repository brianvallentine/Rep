using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V0CLIENTE-NOME-RAZAO
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = (
            SELECT CODCLIEN
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :V1RELATORIOS-APOLICE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = (
											SELECT CODCLIEN
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.V1RELATORIOS_APOLICE}')";

            return query;
        }
        public string V0CLIENTE_NOME_RAZAO { get; set; }
        public string V1RELATORIOS_APOLICE { get; set; }

        public static M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1 m_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = m_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_000_500_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}