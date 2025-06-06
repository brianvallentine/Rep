using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0150_SELECT_ESTR_VIN_Query1 : QueryBasis<M_0150_SELECT_ESTR_VIN_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.COD_AGENCIA,
            T2.COD_ESCNEG,
            T2.REGIAO_ESCNEG,
            T3.COD_FONTE,
            T3.NOME_FONTE
            INTO :AGENCIAS-COD-AGENCIA,
            :ESCRINEG-COD-ESCNEG,
            :ESCRINEG-REGIAO-ESCNEG,
            :FONTES-COD-FONTE,
            :FONTES-NOME-FONTE
            FROM SEGUROS.AGENCIAS_CEF T1,
            SEGUROS.ESCRITORIO_NEGOCIO T2,
            SEGUROS.FONTES T3
            WHERE T1.COD_AGENCIA = :AGENCIAS-COD-AGENCIA
            AND T1.COD_ESCNEG = T2.COD_ESCNEG
            AND T2.COD_FONTE = T3.COD_FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.COD_AGENCIA
							,
											T2.COD_ESCNEG
							,
											T2.REGIAO_ESCNEG
							,
											T3.COD_FONTE
							,
											T3.NOME_FONTE
											FROM SEGUROS.AGENCIAS_CEF T1
							,
											SEGUROS.ESCRITORIO_NEGOCIO T2
							,
											SEGUROS.FONTES T3
											WHERE T1.COD_AGENCIA = '{this.AGENCIAS_COD_AGENCIA}'
											AND T1.COD_ESCNEG = T2.COD_ESCNEG
											AND T2.COD_FONTE = T3.COD_FONTE";

            return query;
        }
        public string AGENCIAS_COD_AGENCIA { get; set; }
        public string ESCRINEG_COD_ESCNEG { get; set; }
        public string ESCRINEG_REGIAO_ESCNEG { get; set; }
        public string FONTES_COD_FONTE { get; set; }
        public string FONTES_NOME_FONTE { get; set; }

        public static M_0150_SELECT_ESTR_VIN_Query1 Execute(M_0150_SELECT_ESTR_VIN_Query1 m_0150_SELECT_ESTR_VIN_Query1)
        {
            var ths = m_0150_SELECT_ESTR_VIN_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0150_SELECT_ESTR_VIN_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0150_SELECT_ESTR_VIN_Query1();
            var i = 0;
            dta.AGENCIAS_COD_AGENCIA = result[i++].Value?.ToString();
            dta.ESCRINEG_COD_ESCNEG = result[i++].Value?.ToString();
            dta.ESCRINEG_REGIAO_ESCNEG = result[i++].Value?.ToString();
            dta.FONTES_COD_FONTE = result[i++].Value?.ToString();
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}