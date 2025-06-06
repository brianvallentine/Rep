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
    public class M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1 : QueryBasis<M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CLIENTES_MOVTO
				SET
				TIPO_MOVIMENTO = 'A' ,
				DATA_ULT_MANUTEN =  '{this.WS_DATA_PROC}' ,
				NOME_RAZAO =  {FieldThreatment((this.VIND_NULL06?.ToInt() == -1 ? null : $"{this.BI0005L_S_NOME_PESSOA}"))},
				TIPO_PESSOA =  {FieldThreatment((this.VIND_NULL07?.ToInt() == -1 ? null : $"{this.BI0005L_S_TIPO_PESSOA}"))},
				IDE_SEXO =  {FieldThreatment((this.VIND_NULL08?.ToInt() == -1 ? null : $"{this.BI0005L_S_SEXO}"))},
				ESTADO_CIVIL =  {FieldThreatment((this.VIND_NULL09?.ToInt() == -1 ? null : $"{this.BI0005L_S_ESTADO_CIVIL}"))},
				OCORR_ENDERECO =  {FieldThreatment((this.VIND_NULL10?.ToInt() == -1 ? null : $"{this.WS_OCC_END_ATU}"))},
				ENDERECO =  {FieldThreatment((this.VIND_NULL11?.ToInt() == -1 ? null : $"{this.BI0005L_S_ENDERECO_R}"))},
				BAIRRO =  {FieldThreatment((this.VIND_NULL12?.ToInt() == -1 ? null : $"{this.BI0005L_S_BAIRRO_R}"))},
				CIDADE =  {FieldThreatment((this.VIND_NULL13?.ToInt() == -1 ? null : $"{this.BI0005L_S_CIDADE_R}"))},
				SIGLA_UF =  {FieldThreatment((this.VIND_NULL14?.ToInt() == -1 ? null : $"{this.BI0005L_S_SIGLA_UF_R}"))},
				CEP =  {FieldThreatment((this.VIND_NULL15?.ToInt() == -1 ? null : $"{this.BI0005L_S_CEP_R}"))},
				DDD =  {FieldThreatment((this.VIND_NULL16?.ToInt() == -1 ? null : $"{this.GECLIMOV_DDD}"))},
				TELEFONE =  {FieldThreatment((this.VIND_NULL17?.ToInt() == -1 ? null : $"{this.GECLIMOV_TELEFONE}"))},
				FAX =  {FieldThreatment((this.VIND_NULL18?.ToInt() == -1 ? null : $"{this.GECLIMOV_FAX}"))},
				CGCCPF =  {FieldThreatment((this.VIND_NULL19?.ToInt() == -1 ? null : $"{this.BI0005L_S_CPF}"))},
				DATA_NASCIMENTO =  {FieldThreatment((this.VIND_NULL20?.ToInt() == -1 ? null : $"{this.BI0005L_S_DATA_NASC}"))},
				COD_USUARIO = 'BI1630B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_CLIENTE =  '{this.WS_COD_CLI_ATU}'
				AND OCORR_HIST =  '{this.WS_OCC_CMO_ATU}'";

            return query;
        }
        public string BI0005L_S_ESTADO_CIVIL { get; set; }
        public string VIND_NULL09 { get; set; }
        public string BI0005L_S_NOME_PESSOA { get; set; }
        public string VIND_NULL06 { get; set; }
        public string BI0005L_S_TIPO_PESSOA { get; set; }
        public string VIND_NULL07 { get; set; }
        public string BI0005L_S_ENDERECO_R { get; set; }
        public string VIND_NULL11 { get; set; }
        public string BI0005L_S_SIGLA_UF_R { get; set; }
        public string VIND_NULL14 { get; set; }
        public string BI0005L_S_DATA_NASC { get; set; }
        public string VIND_NULL20 { get; set; }
        public string BI0005L_S_BAIRRO_R { get; set; }
        public string VIND_NULL12 { get; set; }
        public string BI0005L_S_CIDADE_R { get; set; }
        public string VIND_NULL13 { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_NULL17 { get; set; }
        public string BI0005L_S_CEP_R { get; set; }
        public string VIND_NULL15 { get; set; }
        public string BI0005L_S_SEXO { get; set; }
        public string VIND_NULL08 { get; set; }
        public string WS_OCC_END_ATU { get; set; }
        public string VIND_NULL10 { get; set; }
        public string BI0005L_S_CPF { get; set; }
        public string VIND_NULL19 { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_NULL16 { get; set; }
        public string GECLIMOV_FAX { get; set; }
        public string VIND_NULL18 { get; set; }
        public string WS_DATA_PROC { get; set; }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_OCC_CMO_ATU { get; set; }

        public static void Execute(M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1 m_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1)
        {
            var ths = m_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}