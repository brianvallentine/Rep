using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0530S
{
    public class R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1 : QueryBasis<R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_PEPS
            ,DTA_INIVIG_PEPS
            ,DTA_FIMVIG_PEPS
            ,COD_TP_PEPS
            ,COD_PEPS_EXTERNO
            ,COD_PEPS_RELACIONADO
            ,NUM_CPF_CNPJ
            ,NOM_PEPS
            ,COD_ORGAO_PESS_PEPS
            ,NOM_ORGAO_PEPS
            ,COD_CARGO
            ,NOM_CARGO
            ,COD_COAF
            ,IND_SEXO
            ,NOM_LOGRADOURO
            ,DES_LOGRADOURO
            ,DES_COMPLEMENTO
            ,NOM_BAIRRO
            ,COD_CEP
            ,NOM_MUNICIPIO
            ,COD_UF
            ,DTA_NOMEACAO
            ,DTA_EXONERACAO
            ,NOM_MUNICIPIO_ORGAO
            ,COD_UF_ORGAO
            ,COD_USUARIO
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO
            INTO :GE530-SEQ-PEPS
            ,:GE530-DTA-INIVIG-PEPS
            ,:GE530-DTA-FIMVIG-PEPS
            ,:GE530-COD-TP-PEPS
            ,:GE530-COD-PEPS-EXTERNO
            ,:GE530-COD-PEPS-RELACIONADO
            ,:GE530-NUM-CPF-CNPJ
            ,:GE530-NOM-PEPS
            ,:GE530-COD-ORGAO-PESS-PEPS
            ,:GE530-NOM-ORGAO-PEPS
            ,:GE530-COD-CARGO
            ,:GE530-NOM-CARGO
            ,:GE530-COD-COAF
            ,:GE530-IND-SEXO
            ,:GE530-NOM-LOGRADOURO
            ,:GE530-DES-LOGRADOURO
            ,:GE530-DES-COMPLEMENTO
            ,:GE530-NOM-BAIRRO
            ,:GE530-COD-CEP
            ,:GE530-NOM-MUNICIPIO
            ,:GE530-COD-UF
            ,:GE530-DTA-NOMEACAO
            ,:GE530-DTA-EXONERACAO
            ,:GE530-NOM-MUNICIPIO-ORGAO
            ,:GE530-COD-UF-ORGAO
            ,:GE530-COD-USUARIO
            ,:GE530-NOM-PROGRAMA
            ,:GE530-DTH-CADASTRAMENTO
            FROM SIUS.GE_PEPS_PESSOA_EXPOSTA
            WHERE NUM_CPF_CNPJ = :GE530-NUM-CPF-CNPJ
            AND DTA_FIMVIG_PEPS > :SISTEMAS-DATA-MOV-ABERTO
            ORDER BY DTH_CADASTRAMENTO DESC
            FETCH FIRST ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_PEPS
											,DTA_INIVIG_PEPS
											,DTA_FIMVIG_PEPS
											,COD_TP_PEPS
											,COD_PEPS_EXTERNO
											,COD_PEPS_RELACIONADO
											,NUM_CPF_CNPJ
											,NOM_PEPS
											,COD_ORGAO_PESS_PEPS
											,NOM_ORGAO_PEPS
											,COD_CARGO
											,NOM_CARGO
											,COD_COAF
											,IND_SEXO
											,NOM_LOGRADOURO
											,DES_LOGRADOURO
											,DES_COMPLEMENTO
											,NOM_BAIRRO
											,COD_CEP
											,NOM_MUNICIPIO
											,COD_UF
											,DTA_NOMEACAO
											,DTA_EXONERACAO
											,NOM_MUNICIPIO_ORGAO
											,COD_UF_ORGAO
											,COD_USUARIO
											,NOM_PROGRAMA
											,DTH_CADASTRAMENTO
											FROM SIUS.GE_PEPS_PESSOA_EXPOSTA
											WHERE NUM_CPF_CNPJ = '{this.GE530_NUM_CPF_CNPJ}'
											AND DTA_FIMVIG_PEPS > '{this.SISTEMAS_DATA_MOV_ABERTO}'
											ORDER BY DTH_CADASTRAMENTO DESC
											FETCH FIRST ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE530_SEQ_PEPS { get; set; }
        public string GE530_DTA_INIVIG_PEPS { get; set; }
        public string GE530_DTA_FIMVIG_PEPS { get; set; }
        public string GE530_COD_TP_PEPS { get; set; }
        public string GE530_COD_PEPS_EXTERNO { get; set; }
        public string GE530_COD_PEPS_RELACIONADO { get; set; }
        public string GE530_NUM_CPF_CNPJ { get; set; }
        public string GE530_NOM_PEPS { get; set; }
        public string GE530_COD_ORGAO_PESS_PEPS { get; set; }
        public string GE530_NOM_ORGAO_PEPS { get; set; }
        public string GE530_COD_CARGO { get; set; }
        public string GE530_NOM_CARGO { get; set; }
        public string GE530_COD_COAF { get; set; }
        public string GE530_IND_SEXO { get; set; }
        public string GE530_NOM_LOGRADOURO { get; set; }
        public string GE530_DES_LOGRADOURO { get; set; }
        public string GE530_DES_COMPLEMENTO { get; set; }
        public string GE530_NOM_BAIRRO { get; set; }
        public string GE530_COD_CEP { get; set; }
        public string GE530_NOM_MUNICIPIO { get; set; }
        public string GE530_COD_UF { get; set; }
        public string GE530_DTA_NOMEACAO { get; set; }
        public string GE530_DTA_EXONERACAO { get; set; }
        public string GE530_NOM_MUNICIPIO_ORGAO { get; set; }
        public string GE530_COD_UF_ORGAO { get; set; }
        public string GE530_COD_USUARIO { get; set; }
        public string GE530_NOM_PROGRAMA { get; set; }
        public string GE530_DTH_CADASTRAMENTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1 Execute(R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1 r2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_CONSULTAR_PEP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE530_SEQ_PEPS = result[i++].Value?.ToString();
            dta.GE530_DTA_INIVIG_PEPS = result[i++].Value?.ToString();
            dta.GE530_DTA_FIMVIG_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_TP_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_PEPS_EXTERNO = result[i++].Value?.ToString();
            dta.GE530_COD_PEPS_RELACIONADO = result[i++].Value?.ToString();
            dta.GE530_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.GE530_NOM_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_ORGAO_PESS_PEPS = result[i++].Value?.ToString();
            dta.GE530_NOM_ORGAO_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_CARGO = result[i++].Value?.ToString();
            dta.GE530_NOM_CARGO = result[i++].Value?.ToString();
            dta.GE530_COD_COAF = result[i++].Value?.ToString();
            dta.GE530_IND_SEXO = result[i++].Value?.ToString();
            dta.GE530_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE530_DES_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE530_DES_COMPLEMENTO = result[i++].Value?.ToString();
            dta.GE530_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.GE530_COD_CEP = result[i++].Value?.ToString();
            dta.GE530_NOM_MUNICIPIO = result[i++].Value?.ToString();
            dta.GE530_COD_UF = result[i++].Value?.ToString();
            dta.GE530_DTA_NOMEACAO = result[i++].Value?.ToString();
            dta.GE530_DTA_EXONERACAO = result[i++].Value?.ToString();
            dta.GE530_NOM_MUNICIPIO_ORGAO = result[i++].Value?.ToString();
            dta.GE530_COD_UF_ORGAO = result[i++].Value?.ToString();
            dta.GE530_COD_USUARIO = result[i++].Value?.ToString();
            dta.GE530_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GE530_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}