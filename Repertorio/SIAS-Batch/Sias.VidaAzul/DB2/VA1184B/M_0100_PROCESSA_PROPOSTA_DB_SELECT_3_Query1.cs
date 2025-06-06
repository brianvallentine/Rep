using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN,
            OCORHIST,
            OPCAO_COBER,
            FONTE,
            SITUACAO
            INTO :PROPVA-CODCLIEN,
            :PROPVA-OCORHIST,
            :PROPVA-OPCAO-COBER,
            :PROPVA-FONTE,
            :PROPVA-SITUACAO
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :RELATO-NRCERTIF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
							,
											OCORHIST
							,
											OPCAO_COBER
							,
											FONTE
							,
											SITUACAO
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.RELATO_NRCERTIF}'";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string RELATO_NRCERTIF { get; set; }

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
            dta.PROPVA_CODCLIEN = result[i++].Value?.ToString();
            dta.PROPVA_OCORHIST = result[i++].Value?.ToString();
            dta.PROPVA_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPVA_FONTE = result[i++].Value?.ToString();
            dta.PROPVA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}