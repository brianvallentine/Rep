using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1 : QueryBasis<M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_CLIENTES_MOVTO
            (COD_CLIENTE ,
            OCORR_HIST,
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
            CGCCPF ,
            DATA_NASCIMENTO ,
            COD_USUARIO ,
            TIMESTAMP ,
            DES_COMPLEMENTO)
            VALUES (:WS-COD-CLI-ATU ,
            :WS-OCC-CMO-ATU ,
            'I' ,
            :WS-DATA-PROC ,
            :BI0005L-S-NOME-PESSOA :VIND-NULL06 ,
            :BI0005L-S-TIPO-PESSOA :VIND-NULL07 ,
            :BI0005L-S-SEXO :VIND-NULL08 ,
            :BI0005L-S-ESTADO-CIVIL :VIND-NULL09 ,
            :WS-OCC-END-ATU :VIND-NULL10 ,
            :BI0005L-S-ENDERECO-R :VIND-NULL11 ,
            :BI0005L-S-BAIRRO-R :VIND-NULL12 ,
            :BI0005L-S-CIDADE-R :VIND-NULL13 ,
            :BI0005L-S-SIGLA-UF-R :VIND-NULL14 ,
            :BI0005L-S-CEP-R :VIND-NULL15 ,
            :GECLIMOV-DDD :VIND-NULL16 ,
            :GECLIMOV-TELEFONE :VIND-NULL17 ,
            :GECLIMOV-FAX :VIND-NULL18 ,
            :BI0005L-S-CPF :VIND-NULL19 ,
            :BI0005L-S-DATA-NASC :VIND-NULL20 ,
            'BI1630B' ,
            CURRENT TIMESTAMP ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , OCORR_HIST, TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES ({FieldThreatment(this.WS_COD_CLI_ATU)} , {FieldThreatment(this.WS_OCC_CMO_ATU)} , 'I' , {FieldThreatment(this.WS_DATA_PROC)} ,  {FieldThreatment((this.VIND_NULL06?.ToInt() == -1 ? null : this.BI0005L_S_NOME_PESSOA))} ,  {FieldThreatment((this.VIND_NULL07?.ToInt() == -1 ? null : this.BI0005L_S_TIPO_PESSOA))} ,  {FieldThreatment((this.VIND_NULL08?.ToInt() == -1 ? null : this.BI0005L_S_SEXO))} ,  {FieldThreatment((this.VIND_NULL09?.ToInt() == -1 ? null : this.BI0005L_S_ESTADO_CIVIL))} ,  {FieldThreatment((this.VIND_NULL10?.ToInt() == -1 ? null : this.WS_OCC_END_ATU))} ,  {FieldThreatment((this.VIND_NULL11?.ToInt() == -1 ? null : this.BI0005L_S_ENDERECO_R))} ,  {FieldThreatment((this.VIND_NULL12?.ToInt() == -1 ? null : this.BI0005L_S_BAIRRO_R))} ,  {FieldThreatment((this.VIND_NULL13?.ToInt() == -1 ? null : this.BI0005L_S_CIDADE_R))} ,  {FieldThreatment((this.VIND_NULL14?.ToInt() == -1 ? null : this.BI0005L_S_SIGLA_UF_R))} ,  {FieldThreatment((this.VIND_NULL15?.ToInt() == -1 ? null : this.BI0005L_S_CEP_R))} ,  {FieldThreatment((this.VIND_NULL16?.ToInt() == -1 ? null : this.GECLIMOV_DDD))} ,  {FieldThreatment((this.VIND_NULL17?.ToInt() == -1 ? null : this.GECLIMOV_TELEFONE))} ,  {FieldThreatment((this.VIND_NULL18?.ToInt() == -1 ? null : this.GECLIMOV_FAX))} ,  {FieldThreatment((this.VIND_NULL19?.ToInt() == -1 ? null : this.BI0005L_S_CPF))} ,  {FieldThreatment((this.VIND_NULL20?.ToInt() == -1 ? null : this.BI0005L_S_DATA_NASC))} , 'BI1630B' , CURRENT TIMESTAMP , NULL )";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_OCC_CMO_ATU { get; set; }
        public string WS_DATA_PROC { get; set; }
        public string BI0005L_S_NOME_PESSOA { get; set; }
        public string VIND_NULL06 { get; set; }
        public string BI0005L_S_TIPO_PESSOA { get; set; }
        public string VIND_NULL07 { get; set; }
        public string BI0005L_S_SEXO { get; set; }
        public string VIND_NULL08 { get; set; }
        public string BI0005L_S_ESTADO_CIVIL { get; set; }
        public string VIND_NULL09 { get; set; }
        public string WS_OCC_END_ATU { get; set; }
        public string VIND_NULL10 { get; set; }
        public string BI0005L_S_ENDERECO_R { get; set; }
        public string VIND_NULL11 { get; set; }
        public string BI0005L_S_BAIRRO_R { get; set; }
        public string VIND_NULL12 { get; set; }
        public string BI0005L_S_CIDADE_R { get; set; }
        public string VIND_NULL13 { get; set; }
        public string BI0005L_S_SIGLA_UF_R { get; set; }
        public string VIND_NULL14 { get; set; }
        public string BI0005L_S_CEP_R { get; set; }
        public string VIND_NULL15 { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_NULL16 { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_NULL17 { get; set; }
        public string GECLIMOV_FAX { get; set; }
        public string VIND_NULL18 { get; set; }
        public string BI0005L_S_CPF { get; set; }
        public string VIND_NULL19 { get; set; }
        public string BI0005L_S_DATA_NASC { get; set; }
        public string VIND_NULL20 { get; set; }

        public static void Execute(M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1 m_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1)
        {
            var ths = m_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}