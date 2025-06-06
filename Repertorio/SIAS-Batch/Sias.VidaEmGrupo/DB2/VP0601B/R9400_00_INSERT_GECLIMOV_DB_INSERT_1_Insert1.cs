using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 : QueryBasis<R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_CLIENTES_MOVTO
            (COD_CLIENTE ,
            TIPO_MOVIMENTO ,
            DATA_ULT_MANUTEN ,
            NOME_RAZAO ,
            TIPO_PESSOA ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OCORR_ENDERECO ,
            ENDERECO ,
            BAIRRO ,
            CIDADE ,
            SIGLA_UF ,
            CEP ,
            DDD ,
            TELEFONE ,
            FAX ,
            OCORR_HIST ,
            CGCCPF ,
            DATA_NASCIMENTO ,
            COD_USUARIO ,
            TIMESTAMP ,
            DES_COMPLEMENTO)
            VALUES (:GECLIMOV-COD-CLIENTE ,
            :GECLIMOV-TIPO-MOVIMENTO ,
            :GECLIMOV-DATA-ULT-MANUTEN ,
            :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO ,
            :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA ,
            :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO ,
            :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL ,
            :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END ,
            :GECLIMOV-ENDERECO:VIND-ENDERECO ,
            :GECLIMOV-BAIRRO:VIND-BAIRRO ,
            :GECLIMOV-CIDADE:VIND-CIDADE ,
            :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF ,
            :GECLIMOV-CEP:VIND-CEP ,
            :GECLIMOV-DDD:VIND-DDD ,
            :GECLIMOV-TELEFONE:VIND-TELEFONE ,
            :GECLIMOV-FAX:VIND-FAX ,
            :GECLIMOV-OCORR-HIST ,
            :GECLIMOV-CGCCPF:VIND-CGCCPF ,
            :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC ,
            :GECLIMOV-COD-USUARIO:VIND-CODUSU ,
            CURRENT TIMESTAMP ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES ({FieldThreatment(this.GECLIMOV_COD_CLIENTE)} , {FieldThreatment(this.GECLIMOV_TIPO_MOVIMENTO)} , {FieldThreatment(this.GECLIMOV_DATA_ULT_MANUTEN)} ,  {FieldThreatment((this.VIND_NOME_RAZAO?.ToInt() == -1 ? null : this.GECLIMOV_NOME_RAZAO))} ,  {FieldThreatment((this.VIND_TIPO_PESSOA?.ToInt() == -1 ? null : this.GECLIMOV_TIPO_PESSOA))} ,  {FieldThreatment((this.VIND_IDE_SEXO?.ToInt() == -1 ? null : this.GECLIMOV_IDE_SEXO))} ,  {FieldThreatment((this.VIND_EST_CIVIL?.ToInt() == -1 ? null : this.GECLIMOV_ESTADO_CIVIL))} ,  {FieldThreatment((this.VIND_OCORR_END?.ToInt() == -1 ? null : this.GECLIMOV_OCORR_ENDERECO))} ,  {FieldThreatment((this.VIND_ENDERECO?.ToInt() == -1 ? null : this.GECLIMOV_ENDERECO))} ,  {FieldThreatment((this.VIND_BAIRRO?.ToInt() == -1 ? null : this.GECLIMOV_BAIRRO))} ,  {FieldThreatment((this.VIND_CIDADE?.ToInt() == -1 ? null : this.GECLIMOV_CIDADE))} ,  {FieldThreatment((this.VIND_SIGLA_UF?.ToInt() == -1 ? null : this.GECLIMOV_SIGLA_UF))} ,  {FieldThreatment((this.VIND_CEP?.ToInt() == -1 ? null : this.GECLIMOV_CEP))} ,  {FieldThreatment((this.VIND_DDD?.ToInt() == -1 ? null : this.GECLIMOV_DDD))} ,  {FieldThreatment((this.VIND_TELEFONE?.ToInt() == -1 ? null : this.GECLIMOV_TELEFONE))} ,  {FieldThreatment((this.VIND_FAX?.ToInt() == -1 ? null : this.GECLIMOV_FAX))} , {FieldThreatment(this.GECLIMOV_OCORR_HIST)} ,  {FieldThreatment((this.VIND_CGCCPF?.ToInt() == -1 ? null : this.GECLIMOV_CGCCPF))} ,  {FieldThreatment((this.VIND_DTNASC?.ToInt() == -1 ? null : this.GECLIMOV_DATA_NASCIMENTO))} ,  {FieldThreatment((this.VIND_CODUSU?.ToInt() == -1 ? null : this.GECLIMOV_COD_USUARIO))} , CURRENT TIMESTAMP , NULL)";

            return query;
        }
        public string GECLIMOV_COD_CLIENTE { get; set; }
        public string GECLIMOV_TIPO_MOVIMENTO { get; set; }
        public string GECLIMOV_DATA_ULT_MANUTEN { get; set; }
        public string GECLIMOV_NOME_RAZAO { get; set; }
        public string VIND_NOME_RAZAO { get; set; }
        public string GECLIMOV_TIPO_PESSOA { get; set; }
        public string VIND_TIPO_PESSOA { get; set; }
        public string GECLIMOV_IDE_SEXO { get; set; }
        public string VIND_IDE_SEXO { get; set; }
        public string GECLIMOV_ESTADO_CIVIL { get; set; }
        public string VIND_EST_CIVIL { get; set; }
        public string GECLIMOV_OCORR_ENDERECO { get; set; }
        public string VIND_OCORR_END { get; set; }
        public string GECLIMOV_ENDERECO { get; set; }
        public string VIND_ENDERECO { get; set; }
        public string GECLIMOV_BAIRRO { get; set; }
        public string VIND_BAIRRO { get; set; }
        public string GECLIMOV_CIDADE { get; set; }
        public string VIND_CIDADE { get; set; }
        public string GECLIMOV_SIGLA_UF { get; set; }
        public string VIND_SIGLA_UF { get; set; }
        public string GECLIMOV_CEP { get; set; }
        public string VIND_CEP { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_DDD { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_TELEFONE { get; set; }
        public string GECLIMOV_FAX { get; set; }
        public string VIND_FAX { get; set; }
        public string GECLIMOV_OCORR_HIST { get; set; }
        public string GECLIMOV_CGCCPF { get; set; }
        public string VIND_CGCCPF { get; set; }
        public string GECLIMOV_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }
        public string GECLIMOV_COD_USUARIO { get; set; }
        public string VIND_CODUSU { get; set; }

        public static void Execute(R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1)
        {
            var ths = r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}