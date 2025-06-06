using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1 : QueryBasis<M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :RELATORI-COD-USUARIO
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND COD_RELATORIO = :RELATO-CODRELAT
            AND SIT_REGISTRO = '0'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_RELATORIO = '{this.RELATO_CODRELAT}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string RELATO_CODRELAT { get; set; }

        public static M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1 Execute(M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1 m_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1)
        {
            var ths = m_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}