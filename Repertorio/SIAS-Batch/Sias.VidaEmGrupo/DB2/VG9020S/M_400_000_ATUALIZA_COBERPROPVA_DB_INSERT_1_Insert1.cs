using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1 : QueryBasis<M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.V0COBERPROPVA
            (NRCERTIF ,
            OCORHIST ,
            DTINIVIG ,
            DTTERVIG ,
            IMPSEGUR ,
            QUANT_VIDAS,
            IMPSEGIND ,
            CODOPER ,
            OPCAO_COBER,
            IMPMORNATU ,
            IMPMORACID ,
            IMPINVPERM ,
            IMPAMDS ,
            IMPDH ,
            IMPDIT ,
            VLPREMIO ,
            PRMVG ,
            PRMAP ,
            QTTITCAP ,
            VLTITCAP ,
            VLCUSTCAP ,
            IMPSEGCDC ,
            VLCUSTCDG ,
            CODUSU ,
            TIMESTAMP ,
            IMPSEGAUXF ,
            VLCUSTAUXF ,
            PRMDIT ,
            QTDIT )
            VALUES (:MNUM-CERTIFICADO,
            :V0PROP-OCORHIST,
            :MDATA-MOVIMENTO,
            '9999-12-31' ,
            :V0COBP-IMPSEGUR,
            :V0COBP-QUANT-VIDAS,
            :V0COBP-IMPSEGIND,
            :MCOD-OPERACAO,
            :V0COBP-OPCAO-COBER,
            :V0COBP-IMPMORNATU ,
            :V0COBP-IMPMORACID ,
            :V0COBP-IMPINVPERM ,
            :V0COBP-IMPAMDS ,
            :V0COBP-IMPDH ,
            :V0COBP-IMPDIT ,
            :V0COBP-VLPREMIO ,
            :V0COBP-PRMVG ,
            :V0COBP-PRMAP ,
            :V0COBP-QTTITCAP ,
            :V0COBP-VLTITCAP ,
            :V0COBP-VLCUSTCAP ,
            :V0COBP-IMPSEGCDC ,
            :V0COBP-VLCUSTCDG ,
            :MCOD-USUARIO ,
            CURRENT TIMESTAMP ,
            :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I,
            :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I,
            :V0COBP-PRMDIT:V0COBP-PRMDIT-I,
            :V0COBP-QTDIT:V0COBP-QTDIT-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERPROPVA (NRCERTIF , OCORHIST , DTINIVIG , DTTERVIG , IMPSEGUR , QUANT_VIDAS, IMPSEGIND , CODOPER , OPCAO_COBER, IMPMORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTTITCAP , VLTITCAP , VLCUSTCAP , IMPSEGCDC , VLCUSTCDG , CODUSU , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTDIT ) VALUES ({FieldThreatment(this.MNUM_CERTIFICADO)}, {FieldThreatment(this.V0PROP_OCORHIST)}, {FieldThreatment(this.MDATA_MOVIMENTO)}, '9999-12-31' , {FieldThreatment(this.V0COBP_IMPSEGUR)}, {FieldThreatment(this.V0COBP_QUANT_VIDAS)}, {FieldThreatment(this.V0COBP_IMPSEGIND)}, {FieldThreatment(this.MCOD_OPERACAO)}, {FieldThreatment(this.V0COBP_OPCAO_COBER)}, {FieldThreatment(this.V0COBP_IMPMORNATU)} , {FieldThreatment(this.V0COBP_IMPMORACID)} , {FieldThreatment(this.V0COBP_IMPINVPERM)} , {FieldThreatment(this.V0COBP_IMPAMDS)} , {FieldThreatment(this.V0COBP_IMPDH)} , {FieldThreatment(this.V0COBP_IMPDIT)} , {FieldThreatment(this.V0COBP_VLPREMIO)} , {FieldThreatment(this.V0COBP_PRMVG)} , {FieldThreatment(this.V0COBP_PRMAP)} , {FieldThreatment(this.V0COBP_QTTITCAP)} , {FieldThreatment(this.V0COBP_VLTITCAP)} , {FieldThreatment(this.V0COBP_VLCUSTCAP)} , {FieldThreatment(this.V0COBP_IMPSEGCDC)} , {FieldThreatment(this.V0COBP_VLCUSTCDG)} , {FieldThreatment(this.MCOD_USUARIO)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.V0COBP_IMPSEGAUXF_I?.ToInt() == -1 ? null : this.V0COBP_IMPSEGAUXF))},  {FieldThreatment((this.V0COBP_VLCUSTAUXF_I?.ToInt() == -1 ? null : this.V0COBP_VLCUSTAUXF))},  {FieldThreatment((this.V0COBP_PRMDIT_I?.ToInt() == -1 ? null : this.V0COBP_PRMDIT))},  {FieldThreatment((this.V0COBP_QTDIT_I?.ToInt() == -1 ? null : this.V0COBP_QTDIT))})";

            return query;
        }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string V0COBP_IMPSEGUR { get; set; }
        public string V0COBP_QUANT_VIDAS { get; set; }
        public string V0COBP_IMPSEGIND { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string V0COBP_OPCAO_COBER { get; set; }
        public string V0COBP_IMPMORNATU { get; set; }
        public string V0COBP_IMPMORACID { get; set; }
        public string V0COBP_IMPINVPERM { get; set; }
        public string V0COBP_IMPAMDS { get; set; }
        public string V0COBP_IMPDH { get; set; }
        public string V0COBP_IMPDIT { get; set; }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0COBP_QTTITCAP { get; set; }
        public string V0COBP_VLTITCAP { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }
        public string V0COBP_IMPSEGCDC { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0COBP_IMPSEGAUXF_I { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_VLCUSTAUXF_I { get; set; }
        public string V0COBP_PRMDIT { get; set; }
        public string V0COBP_PRMDIT_I { get; set; }
        public string V0COBP_QTDIT { get; set; }
        public string V0COBP_QTDIT_I { get; set; }

        public static void Execute(M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1 m_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = m_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}