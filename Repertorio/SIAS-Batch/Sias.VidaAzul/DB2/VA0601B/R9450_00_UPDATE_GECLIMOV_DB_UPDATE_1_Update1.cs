using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 : QueryBasis<R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CLIENTES_MOVTO
				SET
				TIPO_MOVIMENTO =  '{this.GECLIMOV_TIPO_MOVIMENTO}',
				DATA_ULT_MANUTEN =  '{this.GECLIMOV_DATA_ULT_MANUTEN}',
				NOME_RAZAO =  {FieldThreatment((this.VIND_NOME_RAZAO?.ToInt() == -1 ? null : $"{this.GECLIMOV_NOME_RAZAO}"))},
				TIPO_PESSOA =  {FieldThreatment((this.VIND_TIPO_PESSOA?.ToInt() == -1 ? null : $"{this.GECLIMOV_TIPO_PESSOA}"))},
				IDE_SEXO =  {FieldThreatment((this.VIND_IDE_SEXO?.ToInt() == -1 ? null : $"{this.GECLIMOV_IDE_SEXO}"))},
				ESTADO_CIVIL =  {FieldThreatment((this.VIND_EST_CIVIL?.ToInt() == -1 ? null : $"{this.GECLIMOV_ESTADO_CIVIL}"))},
				OCORR_ENDERECO =  {FieldThreatment((this.VIND_OCORR_END?.ToInt() == -1 ? null : $"{this.GECLIMOV_OCORR_ENDERECO}"))},
				ENDERECO =  {FieldThreatment((this.VIND_ENDERECO?.ToInt() == -1 ? null : $"{this.GECLIMOV_ENDERECO}"))},
				BAIRRO =  {FieldThreatment((this.VIND_BAIRRO?.ToInt() == -1 ? null : $"{this.GECLIMOV_BAIRRO}"))},
				CIDADE =  {FieldThreatment((this.VIND_CIDADE?.ToInt() == -1 ? null : $"{this.GECLIMOV_CIDADE}"))},
				SIGLA_UF =  {FieldThreatment((this.VIND_SIGLA_UF?.ToInt() == -1 ? null : $"{this.GECLIMOV_SIGLA_UF}"))},
				CEP =  {FieldThreatment((this.VIND_CEP?.ToInt() == -1 ? null : $"{this.GECLIMOV_CEP}"))} ,
				DDD =  {FieldThreatment((this.VIND_DDD?.ToInt() == -1 ? null : $"{this.GECLIMOV_DDD}"))} ,
				TELEFONE =  {FieldThreatment((this.VIND_TELEFONE?.ToInt() == -1 ? null : $"{this.GECLIMOV_TELEFONE}"))} ,
				FAX =  {FieldThreatment((this.VIND_FAX?.ToInt() == -1 ? null : $"{this.GECLIMOV_FAX}"))} ,
				CGCCPF =  {FieldThreatment((this.VIND_CGCCPF?.ToInt() == -1 ? null : $"{this.GECLIMOV_CGCCPF}"))} ,
				DATA_NASCIMENTO =  {FieldThreatment((this.VIND_DTNASC?.ToInt() == -1 ? null : $"{this.GECLIMOV_DATA_NASCIMENTO}"))},
				COD_USUARIO =  '{this.GECLIMOV_COD_USUARIO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_CLIENTE =  '{this.GECLIMOV_COD_CLIENTE}'
				AND OCORR_HIST =  '{this.GECLIMOV_OCORR_HIST}'";

            return query;
        }
        public string GECLIMOV_OCORR_ENDERECO { get; set; }
        public string VIND_OCORR_END { get; set; }
        public string GECLIMOV_TIPO_PESSOA { get; set; }
        public string VIND_TIPO_PESSOA { get; set; }
        public string GECLIMOV_ESTADO_CIVIL { get; set; }
        public string VIND_EST_CIVIL { get; set; }
        public string GECLIMOV_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }
        public string GECLIMOV_NOME_RAZAO { get; set; }
        public string VIND_NOME_RAZAO { get; set; }
        public string GECLIMOV_IDE_SEXO { get; set; }
        public string VIND_IDE_SEXO { get; set; }
        public string GECLIMOV_ENDERECO { get; set; }
        public string VIND_ENDERECO { get; set; }
        public string GECLIMOV_SIGLA_UF { get; set; }
        public string VIND_SIGLA_UF { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_TELEFONE { get; set; }
        public string GECLIMOV_BAIRRO { get; set; }
        public string VIND_BAIRRO { get; set; }
        public string GECLIMOV_CIDADE { get; set; }
        public string VIND_CIDADE { get; set; }
        public string GECLIMOV_CGCCPF { get; set; }
        public string VIND_CGCCPF { get; set; }
        public string GECLIMOV_DATA_ULT_MANUTEN { get; set; }
        public string GECLIMOV_TIPO_MOVIMENTO { get; set; }
        public string GECLIMOV_CEP { get; set; }
        public string VIND_CEP { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_DDD { get; set; }
        public string GECLIMOV_FAX { get; set; }
        public string VIND_FAX { get; set; }
        public string GECLIMOV_COD_USUARIO { get; set; }
        public string GECLIMOV_COD_CLIENTE { get; set; }
        public string GECLIMOV_OCORR_HIST { get; set; }

        public static void Execute(R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1)
        {
            var ths = r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}