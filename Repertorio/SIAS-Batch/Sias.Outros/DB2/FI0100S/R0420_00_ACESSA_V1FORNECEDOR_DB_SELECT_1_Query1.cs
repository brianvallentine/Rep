using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1 : QueryBasis<R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME,
            NUMREC,
            TPPESSOA,
            DCOIRF,
            PCTIRF,
            OPERACAO,
            TIPREG,
            INSPREFE,
            INSESTAD,
            INSINPS,
            CGCCPF,
            DCOISS,
            NUM_DEP_IRF,
            CODSVI_ISS,
            DCOINSS,
            PCTINSS,
            FONTE,
            CEP,
            DATA_ALT_CC,
            PCDESISS,
            OPT_SIMPLES_MUN,
            DATA_NASCIMENTO,
            INV_PERMANENTE
            INTO :V1FAVO-NOMFAV,
            :V1FAVO-NUMREC,
            :V1FAVO-TPPESSOA,
            :V1FAVO-DCOIRF,
            :V1FAVO-PCTIRF,
            :V1FAVO-CODSVI,
            :V1FAVO-TIPREG,
            :V1FAVO-INSPREFE,
            :V1FAVO-INSESTAD,
            :V1FAVO-INSINPS,
            :V1FAVO-CGCCPF,
            :V1FAVO-DCOISS,
            :V1FAVO-NUMDEPIRF,
            :V1FAVO-CODSVISS,
            :V1FAVO-DCOINSS,
            :V1FAVO-PCTINSS,
            :V1FAVO-FONTE,
            :V1FAVO-CEP,
            :V1FAVO-DATA-ALT-CC:VIND-DTALTCC,
            :V1FAVO-PCDESISS:VIND-PCDESISS,
            :V1FAVO-OPT-SIMPLES-M,
            :V4FAVO-DATA-NASC:VIND-DTNASC,
            :V4FAVO-INV-PERMANENTE
            FROM SEGUROS.V1FORNECEDOR
            WHERE CLIFOR = :V1FAVO-CODFAV
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME
							,
											NUMREC
							,
											TPPESSOA
							,
											DCOIRF
							,
											PCTIRF
							,
											OPERACAO
							,
											TIPREG
							,
											INSPREFE
							,
											INSESTAD
							,
											INSINPS
							,
											CGCCPF
							,
											DCOISS
							,
											NUM_DEP_IRF
							,
											CODSVI_ISS
							,
											DCOINSS
							,
											PCTINSS
							,
											FONTE
							,
											CEP
							,
											DATA_ALT_CC
							,
											PCDESISS
							,
											OPT_SIMPLES_MUN
							,
											DATA_NASCIMENTO
							,
											INV_PERMANENTE
											FROM SEGUROS.V1FORNECEDOR
											WHERE CLIFOR = '{this.V1FAVO_CODFAV}'";

            return query;
        }
        public string V1FAVO_NOMFAV { get; set; }
        public string V1FAVO_NUMREC { get; set; }
        public string V1FAVO_TPPESSOA { get; set; }
        public string V1FAVO_DCOIRF { get; set; }
        public string V1FAVO_PCTIRF { get; set; }
        public string V1FAVO_CODSVI { get; set; }
        public string V1FAVO_TIPREG { get; set; }
        public string V1FAVO_INSPREFE { get; set; }
        public string V1FAVO_INSESTAD { get; set; }
        public string V1FAVO_INSINPS { get; set; }
        public string V1FAVO_CGCCPF { get; set; }
        public string V1FAVO_DCOISS { get; set; }
        public string V1FAVO_NUMDEPIRF { get; set; }
        public string V1FAVO_CODSVISS { get; set; }
        public string V1FAVO_DCOINSS { get; set; }
        public string V1FAVO_PCTINSS { get; set; }
        public string V1FAVO_FONTE { get; set; }
        public string V1FAVO_CEP { get; set; }
        public string V1FAVO_DATA_ALT_CC { get; set; }
        public string VIND_DTALTCC { get; set; }
        public string V1FAVO_PCDESISS { get; set; }
        public string VIND_PCDESISS { get; set; }
        public string V1FAVO_OPT_SIMPLES_M { get; set; }
        public string V4FAVO_DATA_NASC { get; set; }
        public string VIND_DTNASC { get; set; }
        public string V4FAVO_INV_PERMANENTE { get; set; }
        public string V1FAVO_CODFAV { get; set; }

        public static R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1 Execute(R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1 r0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FAVO_NOMFAV = result[i++].Value?.ToString();
            dta.V1FAVO_NUMREC = result[i++].Value?.ToString();
            dta.V1FAVO_TPPESSOA = result[i++].Value?.ToString();
            dta.V1FAVO_DCOIRF = result[i++].Value?.ToString();
            dta.V1FAVO_PCTIRF = result[i++].Value?.ToString();
            dta.V1FAVO_CODSVI = result[i++].Value?.ToString();
            dta.V1FAVO_TIPREG = result[i++].Value?.ToString();
            dta.V1FAVO_INSPREFE = result[i++].Value?.ToString();
            dta.V1FAVO_INSESTAD = result[i++].Value?.ToString();
            dta.V1FAVO_INSINPS = result[i++].Value?.ToString();
            dta.V1FAVO_CGCCPF = result[i++].Value?.ToString();
            dta.V1FAVO_DCOISS = result[i++].Value?.ToString();
            dta.V1FAVO_NUMDEPIRF = result[i++].Value?.ToString();
            dta.V1FAVO_CODSVISS = result[i++].Value?.ToString();
            dta.V1FAVO_DCOINSS = result[i++].Value?.ToString();
            dta.V1FAVO_PCTINSS = result[i++].Value?.ToString();
            dta.V1FAVO_FONTE = result[i++].Value?.ToString();
            dta.V1FAVO_CEP = result[i++].Value?.ToString();
            dta.V1FAVO_DATA_ALT_CC = result[i++].Value?.ToString();
            dta.VIND_DTALTCC = string.IsNullOrWhiteSpace(dta.V1FAVO_DATA_ALT_CC) ? "-1" : "0";
            dta.V1FAVO_PCDESISS = result[i++].Value?.ToString();
            dta.VIND_PCDESISS = string.IsNullOrWhiteSpace(dta.V1FAVO_PCDESISS) ? "-1" : "0";
            dta.V1FAVO_OPT_SIMPLES_M = result[i++].Value?.ToString();
            dta.V4FAVO_DATA_NASC = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.V4FAVO_DATA_NASC) ? "-1" : "0";
            dta.V4FAVO_INV_PERMANENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}