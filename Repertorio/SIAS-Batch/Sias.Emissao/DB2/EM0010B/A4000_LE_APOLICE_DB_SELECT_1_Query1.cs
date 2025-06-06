using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A4000_LE_APOLICE_DB_SELECT_1_Query1 : QueryBasis<A4000_LE_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN, NUM_APOLICE,
            MODALIDA, ORGAO, RAMO,
            TIPSGU, TIPAPO, TIPCALC,
            IDEMAN, PCDESCON, PCIOCC,
            TPCOSCED, QTCOSSEG, PCTCED,
            TPPESSOA
            INTO :APOL-COD-CLIENTE
            ,:APOL-NUM-APOLICE
            ,:APOL-MODALIDA
            ,:APOL-ORGAO
            ,:APOL-RAMO
            ,:APOL-TIPO-SEGURO
            ,:APOL-TIPO-APOLICE
            ,:APOL-TIPO-CALCULO
            ,:APOL-IND-ENDOS-MAN
            ,:APOL-PCDESCON
            ,:APOL-PCIOCC
            ,:APOL-TPCOSSEG
            ,:APOL-QTCOSSEG
            ,:APOL-PCCOSSEG
            ,:APOL-TIPO-PESSOA
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
							, NUM_APOLICE
							,
											MODALIDA
							, ORGAO
							, RAMO
							,
											TIPSGU
							, TIPAPO
							, TIPCALC
							,
											IDEMAN
							, PCDESCON
							, PCIOCC
							,
											TPCOSCED
							, QTCOSSEG
							, PCTCED
							,
											TPPESSOA
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOL_COD_CLIENTE { get; set; }
        public string APOL_NUM_APOLICE { get; set; }
        public string APOL_MODALIDA { get; set; }
        public string APOL_ORGAO { get; set; }
        public string APOL_RAMO { get; set; }
        public string APOL_TIPO_SEGURO { get; set; }
        public string APOL_TIPO_APOLICE { get; set; }
        public string APOL_TIPO_CALCULO { get; set; }
        public string APOL_IND_ENDOS_MAN { get; set; }
        public string APOL_PCDESCON { get; set; }
        public string APOL_PCIOCC { get; set; }
        public string APOL_TPCOSSEG { get; set; }
        public string APOL_QTCOSSEG { get; set; }
        public string APOL_PCCOSSEG { get; set; }
        public string APOL_TIPO_PESSOA { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }

        public static A4000_LE_APOLICE_DB_SELECT_1_Query1 Execute(A4000_LE_APOLICE_DB_SELECT_1_Query1 a4000_LE_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = a4000_LE_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A4000_LE_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A4000_LE_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOL_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOL_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOL_MODALIDA = result[i++].Value?.ToString();
            dta.APOL_ORGAO = result[i++].Value?.ToString();
            dta.APOL_RAMO = result[i++].Value?.ToString();
            dta.APOL_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.APOL_TIPO_APOLICE = result[i++].Value?.ToString();
            dta.APOL_TIPO_CALCULO = result[i++].Value?.ToString();
            dta.APOL_IND_ENDOS_MAN = result[i++].Value?.ToString();
            dta.APOL_PCDESCON = result[i++].Value?.ToString();
            dta.APOL_PCIOCC = result[i++].Value?.ToString();
            dta.APOL_TPCOSSEG = result[i++].Value?.ToString();
            dta.APOL_QTCOSSEG = result[i++].Value?.ToString();
            dta.APOL_PCCOSSEG = result[i++].Value?.ToString();
            dta.APOL_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}