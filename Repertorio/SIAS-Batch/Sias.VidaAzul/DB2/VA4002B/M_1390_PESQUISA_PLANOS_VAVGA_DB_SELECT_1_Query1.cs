using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1 : QueryBasis<M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIOTOT,
            IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT
            INTO :PLAVAVGA-VLPREMIOTOT,
            :PLAVAVGA-IMPMORNATU,
            :PLAVAVGA-IMPMORACID,
            :PLAVAVGA-IMPINVPERM,
            :PLAVAVGA-IMPAMDS,
            :PLAVAVGA-IMPDH,
            :PLAVAVGA-IMPDIT
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            AND OPCAO_COBER = :PROPVA-OPCAO-COBER
            AND IDADE_INICIAL <= :PROPVA-IDADE
            AND IDADE_FINAL >= :PROPVA-IDADE
            AND DTTERVIG = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIOTOT
							,
											IMPMORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND OPCAO_COBER = '{this.PROPVA_OPCAO_COBER}'
											AND IDADE_INICIAL <= '{this.PROPVA_IDADE}'
											AND IDADE_FINAL >= '{this.PROPVA_IDADE}'
											AND DTTERVIG = '9999-12-31'
											WITH UR";

            return query;
        }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PLAVAVGA_IMPMORNATU { get; set; }
        public string PLAVAVGA_IMPMORACID { get; set; }
        public string PLAVAVGA_IMPINVPERM { get; set; }
        public string PLAVAVGA_IMPAMDS { get; set; }
        public string PLAVAVGA_IMPDH { get; set; }
        public string PLAVAVGA_IMPDIT { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_IDADE { get; set; }

        public static M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1 Execute(M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1 m_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1)
        {
            var ths = m_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_VLPREMIOTOT = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPMORNATU = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPMORACID = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPINVPERM = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPAMDS = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPDH = result[i++].Value?.ToString();
            dta.PLAVAVGA_IMPDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}